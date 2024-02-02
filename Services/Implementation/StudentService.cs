using System.ComponentModel;
using System.Diagnostics;
using NationalExamReporter.Constants;
using NationalExamReporter.Entities;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.UnitOfWork.Repositories;
using NationalExamReporter.UnitOfWork.Repositories.Implementation;


namespace NationalExamReporter.Services.Implementation;

public class StudentService : IStudentService
{
    public event ProgressChangedEventHandler? ProgressChanged;
    private int _studentCount;
    private int _totalCsvStudentCount;
    private int _progress;
    private ISchoolYearRepository? _schoolYearRepository;
    private IStudentRepository? _studentRepository;
    private IScoreService? _scoreService;
    private int _year;
    private List<CsvStudentVer2>? _csvStudents;
    private List<Student>? _studentsBuffer;
    private int _bufferIndex;
    private BackgroundWorker? _backgroundWorker;


    public StudentService()
    {
    }

    public void InsertStudentsData(StudentServiceParameters parameters)
    {
        InitializeObjects();
        AssignValuesToPrivateMembers(parameters);
        _backgroundWorker!.DoWork += (sender, e) => { InsertInMultipleThreads(); };
        _backgroundWorker!.RunWorkerAsync();
    }

    private void InsertInMultipleThreads()
    {
        while (_studentCount != _totalCsvStudentCount)
        {
            CsvStudentVer2 csvStudent = _csvStudents![_studentCount];
            Student student = GetStudentFromCsvStudent(csvStudent);

            _scoreService!.InsertScoresPerStudent(new ScoreServiceParameters()
            {
                CsvStudent = csvStudent,
                Student = student
            });

            _studentsBuffer?.Add(student);
            _progress = GetInsertProgress();
            ReportProgress();
            IncrementIndices();
            if (IsBufferMaxed()) HandleBufferMaxed();
        }
    }

    private Student GetStudentFromCsvStudent(CsvStudentVer2 csvStudent)
    {
        Student student = new Student()
        {
            StudentCode = csvStudent.StudentId!,
            Status = true
        };
        student.SchoolYearId = _schoolYearRepository!.GetSchoolYearIdBySchoolYear(csvStudent.Year);
        student.Id = (int)(_studentCount + 1);

        return student;
    }

    private void InitializeObjects()
    {
        _schoolYearRepository = new SchoolYearRepository();
        _studentRepository = new StudentRepository();
        _scoreService = new ScoreService(_totalCsvStudentCount);
        _studentCount = 0;
        _bufferIndex = 0;
        _studentsBuffer = new List<Student>();
        _backgroundWorker = new BackgroundWorker() { WorkerReportsProgress = true };
    }

    private void AssignValuesToPrivateMembers(StudentServiceParameters parameters)
    {
        _year = parameters.Year;
        _csvStudents = parameters.CsvStudents;
        _totalCsvStudentCount = _csvStudents!.Count;
    }

    private void IncrementIndices()
    {
        _bufferIndex++;
        _studentCount++;
    }

    private int GetInsertProgress()
    {
        return (int)((double)GetCurrentStudentCount() / _totalCsvStudentCount * 100);
    }


    private void HandleBufferMaxed()
    {
        _studentRepository!.BulkInsertStudents(_studentsBuffer!.ToList()!);
        _studentsBuffer!.Clear();
        _scoreService!.HandleBufferMaxed();
        _bufferIndex = 0;
    }


    private int GetToIndexByBufferSize()
    {
        return _studentCount + BufferSize.STUDENT_BUFFER_SIZE;
    }

    private void UpdateCurrentIndex()
    {
        _studentCount = GetToIndexByBufferSize();
    }

    private int GetCurrentStudentCount()
    {
        int result = _studentCount + 1;
        return result;
    }

    private bool IsBufferMaxed()
    {
        if (_studentCount % BufferSize.STUDENT_BUFFER_SIZE == 0) return true;
        return false;
    }

    private void ReportProgress()
    {
        string progressByString = $"{_studentCount}/{_totalCsvStudentCount} ({_progress}%)";
        ProgressChanged!(this, new ProgressChangedEventArgs(_progress, progressByString));
    }
}