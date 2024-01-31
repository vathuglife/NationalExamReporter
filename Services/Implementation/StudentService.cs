using System.ComponentModel;
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
    private int _currentIndex;
    private int _schoolYearId;
    private int _totalCsvStudentCount;
    private int _progress;
    private ISchoolYearRepository? _schoolYearRepository;
    private IStudentRepository? _studentRepository;
    private IScoreService? _scoreService;
    private int _year;
    private List<CsvStudent>? _csvStudents;
    private Student[]? _studentsBuffer;
    private int _bufferIndex;
    private BackgroundWorker? _backgroundWorker;


    public StudentService()
    {
        InitializeObjects();
    }

    public void InsertStudentsData(StudentServiceParameters parameters)
    {
        AssignValuesToPrivateMembers(parameters);
        _schoolYearId = _schoolYearRepository!.GetSchoolYearIdBySchoolYear(_year);
        _currentIndex = 0;
        _bufferIndex = 0;
        _backgroundWorker!.DoWork += (sender, e) => { InsertInMultipleThreads(); };

        _backgroundWorker!.RunWorkerAsync();
    }

    private void InsertInMultipleThreads()
    {
        while (_currentIndex != _totalCsvStudentCount)
        {
            int toIndex = GetToIndexByBufferSize();
            Parallel.For((long)_currentIndex, toIndex, index =>
            {
                CsvStudent csvStudent = _csvStudents![(int)index];
                Student student = GetStudentFromCsvStudent(csvStudent, _schoolYearId);
                student.Scores =
                    _scoreService!.GetScoresPerStudent(new ScoreServiceParameters()
                    {
                        CsvStudent = csvStudent,
                        Student = student
                    });
                _studentsBuffer![_bufferIndex] = student;
                _bufferIndex++;
                _progress = GetInsertProgress();
                ReportProgress();
            });
            HandleBufferMaxed();
            UpdateCurrentIndex();
            _bufferIndex = 0;
        }
    }

    private Student GetStudentFromCsvStudent(CsvStudent csvStudent, int schoolYearId)
    {
        Student student = new Student()
        {
            SchoolYearId = schoolYearId,
            StudentCode = csvStudent.StudentId!,
            Status = true
        };
        return student;
    }

    private void InitializeObjects()
    {
        _schoolYearRepository = new SchoolYearRepository();
        _studentRepository = new StudentRepository();
        _scoreService = new ScoreService();
        _studentsBuffer = new Student[BufferSize.STUDENT_BUFFER_SIZE];
        _backgroundWorker = new BackgroundWorker() { WorkerReportsProgress = true };
    }

    private void AssignValuesToPrivateMembers(StudentServiceParameters parameters)
    {
        _year = parameters.Year;
        _csvStudents = parameters.CsvStudents;
        _totalCsvStudentCount = _csvStudents!.Count;
    }

    private int GetInsertProgress()
    {
        return (int)((double)GetCurrentStudentCount() / _totalCsvStudentCount * 100);
    }


    private void HandleBufferMaxed()
    {
        _studentRepository!.BulkInsertStudents(_studentsBuffer!.ToList()!);
        Array.Clear(_studentsBuffer!);
    }


    private int GetToIndexByBufferSize()
    {
        return _currentIndex + BufferSize.STUDENT_BUFFER_SIZE;
    }

    private void UpdateCurrentIndex()
    {
        _currentIndex = GetToIndexByBufferSize();
    }

    private int GetCurrentStudentCount()
    {
        int result = _currentIndex + 1;
        return result;
    }

    private void ReportProgress()
    {
        string progressByString = $"Current Progress: ${_progress}";
        ProgressChanged!(this, new ProgressChangedEventArgs(_progress, progressByString));
    }
}