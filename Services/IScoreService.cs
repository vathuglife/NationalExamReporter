using NationalExamReporter.Entities;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services;

public interface IScoreService
{
    List<Score> GetScoresPerStudent(ScoreServiceParameters parameters);
}