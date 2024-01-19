using NationalExamReporter.Enums;
using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface ICsvFileByYearService
{
    public CsvFileByYearServiceResult AppendCsvFileByYearToLoadedCsv(CsvFileByYear csvFileByYear);
    public CsvFileByYearServiceResult RemoveCsvFileByYearFromLoadedCsv(int index);
    public List<CsvFileByYear> GetCsvFileByYearFromLoadedCsv();
}