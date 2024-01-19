using NationalExamReporter.Constants;
using NationalExamReporter.Enums;
using NationalExamReporter.Models;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Utils;

namespace NationalExamReporter.ViewModels.CsvFileByYearViewModel;

public class DeleteCsvFileByYearViewModel
{
    private ICsvFileByYearService? _csvFileByYearService;

    public DeleteCsvFileByYearViewModel()
    {
        InitializeObjects();
    }
    public List<CsvFileByYear> GetCsvFileByYears()
    {
        return _csvFileByYearService!.GetCsvFileByYearFromLoadedCsv();
    }

    public CsvFileByYearServiceResult DeleteCsvFromLoadedCsv(int index)
    {
        return _csvFileByYearService!.RemoveCsvFileByYearFromLoadedCsv(index);
    }

    private void InitializeObjects()
    {
        _csvFileByYearService = new CsvFileByYearService();
    }
}