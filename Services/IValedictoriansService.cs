using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface IValedictoriansService
{
    ValedictoriansServiceReturnValue GetValedictoriansDetails(List<CsvStudent> csvStudents);
    Task<ValedictoriansServiceReturnValue> GetValedictoriansDetails(int selectedYear);
    int[] GetYears();
}