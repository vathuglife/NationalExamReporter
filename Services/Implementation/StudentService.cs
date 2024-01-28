using System.Collections.Concurrent;
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
    private List<CsvStudent>? _csvStudents;
    private Student[]? _studentsBuffer;
    private BackgroundWorker? _backgroundWorker;


    public StudentService()
    {
        InitializeObjects();
    }

    public void InsertStudentsData(StudentServiceParameters parameters)
    {
        AssignValuesToPrivateMembers(parameters);
        int schoolYearId = _schoolYearRepository!.GetSchoolYearIdBySchoolYear(_year);

        _backgroundWorker!.DoWork += (sender, e) =>
        {
            Parallel.For((long)0, 15000, index =>
            {
                CsvStudent csvStudent = _csvStudents[(int)index];
                Student student = GetStudentFromCsvStudent(csvStudent, schoolYearId);
                _studentsBuffer![index] = student;
                _studentCount++;
                _progress = GetInsertProgress();
                _scoreService!.InsertStudentScoreToScoreTable(new ScoreServiceParameters()
                {
                    CsvStudent = csvStudent,
                    Student = student,
                    TotalScoreCount = _totalCsvStudentCount * NationalExamConstants.NUMBER_OF_SUBJECTS
                });
                if (IsBufferMaxed()) HandleBufferMaxed();
            });
        };

        _backgroundWorker!.RunWorkerAsync();
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

    private bool IsBufferMaxed()
    {
        if (_studentCount % BufferSize.STUDENT_BUFFER_SIZE == 0
            || _studentCount == _totalCsvStudentCount)
            return true;
        return false;
    }

    private int GetInsertProgress()
    {
        return (int)((double)_studentCount / _totalCsvStudentCount * 100);
    }

    private ConcurrentBag<Student> RemoveDuplicatesFromBag()
    {
        return new ConcurrentBag<Student>(_studentsBuffer!.GroupBy(student => student.Id)
            .Select(group => group.First()));
    }

    private void HandleBufferMaxed()
    {
        RemoveDuplicatesFromBag();
        _studentRepository!.BulkInsertStudents(_studentsBuffer!.ToList()!);
        Array.Clear(_studentsBuffer!);
    }
}