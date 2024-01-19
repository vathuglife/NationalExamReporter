using NationalExamReporter.Constants;
using NationalExamReporter.Enums;
using NationalExamReporter.Models;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Utils;

namespace NationalExamReporter.ViewModels.CsvFileByYearViewModel;

public class AddCsvFileByYearViewModel
{
    private ICsvFileByYearService _csvFileByYearService;

    public AddCsvFileByYearViewModel()
    {
        InitializeObjects();
    }

    public string GetCsvFilePath()
    {
        return FileChooserUtils.GetFilePath(OpenFileDialogFilterExtensions.CSV_FILTER);
    }

    public CsvFileByYearServiceResult FinishImportCsv(CsvFileByYear csvFileByYear)
    {
        return _csvFileByYearService.AppendCsvFileByYearToLoadedCsv(csvFileByYear);
    }

    private void InitializeObjects()
    {
        _csvFileByYearService = new CsvFileByYearService();
    }
}