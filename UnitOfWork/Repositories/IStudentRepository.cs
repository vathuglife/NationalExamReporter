using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories;

public interface IStudentRepository
{
    void InsertNewStudent(Student student);
    void BulkInsertStudents(IEnumerable<Student> students);
}