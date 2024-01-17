using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface ICsvFileByYearService
{
    public List<CsvFileByYear> GetLoadedCsv();
}