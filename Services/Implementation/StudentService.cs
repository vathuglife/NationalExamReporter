using NationalExamReporter.Constants;
using NationalExamReporter.Entities;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.UnitOfWork.Repositories;
using NationalExamReporter.UnitOfWork.Repositories.Implementation;

namespace NationalExamReporter.Services.Implementation;

public class StudentService : IStudentService
{
    private ISchoolYearRepository? _schoolYearRepository;
    private IStudentRepository? _studentRepository;
    private IScoreService? _scoreService;
    private int _year;
    private List<CsvStudent>? _csvStudents;
    private List<Student>? _studentsBufferList;
    private int _studentCount;
    private int _totalCsvStudentCount;

    public StudentService()
    {
        InitializeObjects();
    }
    
    public void InsertStudentsData(StudentServiceParameters parameters)
    {
        AssignValuesToPrivateMembers(parameters);
        int schoolYearId = _schoolYearRepository!.GetSchoolYearIdBySchoolYear(_year);
        foreach (CsvStudent csvStudent in _csvStudents!)
        {
            Student student = GetStudentFromCsvStudent(csvStudent, schoolYearId);
            _studentsBufferList!.Add(student);
            _studentCount++;
            _scoreService!.InsertStudentScoreToScoreTable(new ScoreServiceParameters()
            {
                CsvStudent = csvStudent,
                Student = student,
                TotalScoreCount =  _totalCsvStudentCount * NationalExamConstants.NUMBER_OF_SUBJECTS
            });
            if (IsBufferMaxed()) HandleBufferMaxed();
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
        _studentRepository!.InsertNewStudent(student);
        return student;
    }

    private void InitializeObjects()
    {
        _schoolYearRepository = new SchoolYearRepository();
        _studentRepository = new StudentRepository();
        _scoreService = new ScoreService();
        _studentsBufferList = new List<Student>();
        _studentCount = 0;
        _totalCsvStudentCount = 0;
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

    private void HandleBufferMaxed()
    {
        _studentRepository!.BulkInsertStudents(_studentsBufferList!);
        _studentsBufferList!.Clear();
    }
}