using NationalExamReporter.Entities;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services;

public interface IScoreService
{
    void InsertScoresPerStudent(ScoreServiceParameters parameters);
    void HandleBufferMaxed();
}