using System.ComponentModel;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services;

public interface IStudentService
{
    event ProgressChangedEventHandler ProgressChanged;
    void InsertStudentsData(StudentServiceParameters parameters);
}