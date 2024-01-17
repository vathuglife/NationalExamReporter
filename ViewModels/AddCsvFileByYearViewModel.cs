using NationalExamReporter.Constants;
using NationalExamReporter.Models;
using NationalExamReporter.Utils;

namespace NationalExamReporter.ViewModels;

public class AddCsvFileByYearViewModel
{
    public string GetCsvFilePath()
    {
        return FileChooserUtils.GetFilePath(OpenFileDialogFilterExtensions.CSV_FILTER);
    }

    public void FinishImportCsv(CsvFileByYear csvFileByYear)
    {
        JsonUtils.AppendToFile(ConfigPaths.LoadedCsv,csvFileByYear);
    }
}