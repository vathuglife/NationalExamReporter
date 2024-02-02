using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services;

public interface IValedictoriansService
{
    ValedictoriansServiceReturnValue GetValedictoriansDetails(List<CsvStudent> csvStudents);
    Task<ValedictoriansServiceReturnValue> GetValedictoriansDetails(ValedictoriansParameters parameters);
    int[] GetYears();
}