using NationalExamReporter.Constants;
using NationalExamReporter.Enums;
using NationalExamReporter.Models;
using NationalExamReporter.Utils;

namespace NationalExamReporter.Services.Implementation;

public class CsvFileByYearService:ICsvFileByYearService
{
    private List<CsvFileByYear>? _loadedCsvList;

    public CsvFileByYearService()
    {
        RefreshLoadedCsv();
    }
    public CsvFileByYearServiceResult AppendCsvFileByYearToLoadedCsv(CsvFileByYear csvFileByYear)
    {
        RefreshLoadedCsv();
        if (IsYearDuplicated(csvFileByYear)) return CsvFileByYearServiceResult.DUPLICATED;
        JsonUtils.AppendToFile(ConfigPaths.LoadedCsv,csvFileByYear);
        return CsvFileByYearServiceResult.SUCCESS;
    }

    public CsvFileByYearServiceResult RemoveCsvFileByYearFromLoadedCsv(int index)
    {
        JsonUtils.RemoveFromFileByIndex<CsvFileByYear>(ConfigPaths.LoadedCsv,index);
        return CsvFileByYearServiceResult.SUCCESS;
    }

    public List<CsvFileByYear> GetCsvFileByYearFromLoadedCsv()
    {
        return JsonUtils.DeserializeObjectList<CsvFileByYear>(
            ConfigPaths.LoadedCsv);
    }

    private void RefreshLoadedCsv()
    {
        _loadedCsvList = JsonUtils.DeserializeObjectList<CsvFileByYear>(ConfigPaths.LoadedCsv);
    }

    private bool IsYearDuplicated(CsvFileByYear csvFileByYear)
    {
        int year = csvFileByYear.Year;
        foreach (CsvFileByYear loadedCsv in _loadedCsvList!)
        {
            if (loadedCsv.Year == year) return true;
        }

        return false;
    }
}