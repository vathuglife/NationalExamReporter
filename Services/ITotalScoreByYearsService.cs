using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface ITotalScoreByYearsService
{
    public TotalScoresByYearsServiceReturnValue GetTotalScoresByYears(string csvPath);
}