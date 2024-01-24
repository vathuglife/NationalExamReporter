using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services;

public interface IScoreService
{
    void InsertStudentScoreToScoreTable(ScoreServiceParameters parameters);
}