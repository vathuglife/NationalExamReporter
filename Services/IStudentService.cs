using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services;

public interface IStudentService
{
    void InsertStudentsData(StudentServiceParameters parameters );
}