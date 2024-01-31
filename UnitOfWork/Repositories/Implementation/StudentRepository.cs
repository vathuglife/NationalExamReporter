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

    public async void BulkInsertStudents(List<Student> students)
    {
        // await _dbContext.Students.AddRangeAsync(students);    
        // await _dbContext.SaveChangesAsync();
        // foreach (Student student in students)
        // {
        //     using(var context = new NationalExamReporterDBContext())
        //     {
        //         context?.Students!.Add(student);
        //         context?.SaveChanges();
        //     }
        // }
        _dbContext?.BulkInsertAsync(students);
    }

    private void InitializeObjects()
    {
        _dbContext = new NationalExamReporterDBContext();       
    }
    
}