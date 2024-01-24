using EFCore.BulkExtensions;
using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories.Implementation;

public class ScoreRepository:IScoreRepository,IDisposable
{
    private NationalExamReporterDBContext? _dbContext;

    public ScoreRepository()
    {
        InitializeObjects();
    }
    public void InsertNewScore(Score score)
    {
        _dbContext?.Scores?.Add(score);
        _dbContext?.SaveChanges();
    }

    public void BulkInsertScore(List<Score> scores)
    {
        _dbContext?.BulkInsert(scores);
        _dbContext?.SaveChanges();
    }
    private void InitializeObjects()
    {
        _dbContext = new NationalExamReporterDBContext();       
    }
    public void Dispose()
    {
        Dispose();
        GC.SuppressFinalize(this);
    }

    
}