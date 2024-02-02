using EFCore.BulkExtensions;
using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories.Implementation;

public class StudentRepository :IStudentRepository
{
    private NationalExamReporterDBContext? _dbContext;

    public StudentRepository()
    {
        InitializeObjects();
    }
    public void InsertNewStudent(Student student)
    {
        _dbContext?.Students?.Add(student);
        _dbContext?.SaveChanges();
    }

    public void BulkInsertStudents(IEnumerable<Student> students)
    {
        using (_dbContext = new NationalExamReporterDBContext())
        {
            _dbContext?.AddRange(students);        
            _dbContext?.SaveChanges();    
        }
    }

    private void InitializeObjects()
    {
        _dbContext = new NationalExamReporterDBContext();       
    }
    
}