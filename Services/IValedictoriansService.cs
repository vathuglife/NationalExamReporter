using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface IValedictoriansService
{
    List<ValedictoriansDetails> GetValedictoriansDetails(List<CsvStudent> csvStudents);
}