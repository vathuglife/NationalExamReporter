using NationalExamReporter.Constants;
using NationalExamReporter.Models;
using NationalExamReporter.Utils;

namespace NationalExamReporter.Services.Implementation;

public class CsvFileByYearService:ICsvFileByYearService
{
    private List<CsvFileByYear> _loadedCsv;
    public List<CsvFileByYear> GetLoadedCsv()
    {
        return JsonUtils.DeserializeObjectList<CsvFileByYear>(ConfigPaths.LoadedCsv);
    }
}