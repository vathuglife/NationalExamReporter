using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories.Implementation;

public class SubjectRepository : ISubjectRepository
{
    private NationalExamReporterDBContext? _dbContext;

    public SubjectRepository()
    {
        InitializeObjects();
       
    }
    public void InsertNewSubject(Subject subject)
    {
        _dbContext?.Subjects?.Add(subject);
        _dbContext?.SaveChanges();
    }

    public int GetSubjectIdBySubjectName(string subjectName)
    {
        Subject subject = GetNewDbContextInstance()?.Subjects?.Where(subject => subject.Code == subjectName)!.First()!;
        return subject.Id;
    }

    private void InitializeObjects()
    {
        _dbContext = GetNewDbContextInstance();
    }
    private NationalExamReporterDBContext GetNewDbContextInstance()
    {
        return new NationalExamReporterDBContext();
    }
}