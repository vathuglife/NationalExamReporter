using NationalExamReporter.Models;

namespace NationalExamReporter.Services.Implementation;

public class TotalScoresByYearsService:ITotalScoreByYearsService
{
    private ICsvService? _csvService;
    private List<TotalScoresByYears>? _totalScoresByYears;
    private List<CsvStudentVer2> _csvStudentResult;
    public TotalScoresByYearsService()
    {
        InitializeObjects();
    }
    public TotalScoresByYearsServiceReturnValue GetTotalScoresByYears(string csvPath)
    {
        _csvStudentResult =  _csvService!.ReadCsvVer2(csvPath);
        GetTotalScoresByYears();
        
        return GetReturnValue();
    }

    private void GetTotalScoresByYears()
    {
        var groupsByYear = _csvStudentResult.GroupBy(csvStudent => csvStudent.Year);
        foreach (var group in groupsByYear)
        {
            TotalScoresByYears totalScoresByYears = new TotalScoresByYears()
            {
                Year = group.Key,
                Student = group.Count(),
                Mathematics = group.Count(student => student.Mathematics > 0),
                Literature = group.Count(student => student.Literature > 0),
                Physics = group.Count(student => student.Physics > 0),
                Biology = group.Count(student => student.Biology > 0),
                English = group.Count(student => student.English > 0),
                Chemistry = group.Count(student => student.Chemistry > 0),
                History = group.Count(student => student.History > 0),
                Geography = group.Count(student => student.Geography > 0),
                CivicEducation = group.Count(student => student.CivicEducation > 0)
            };
            _totalScoresByYears!.Add(totalScoresByYears);
        }
    }

    private TotalScoresByYearsServiceReturnValue GetReturnValue()
    {
        return new TotalScoresByYearsServiceReturnValue()
        {
            CsvStudents = _csvStudentResult,
            TotalScoresByYears = _totalScoresByYears!
        };
    }
    private void InitializeObjects()
    {
        // _averageScoreService = new AverageScoreService();
        _totalScoresByYears = new List<TotalScoresByYears>();
        _csvService = new CsvService();
    }
    
}