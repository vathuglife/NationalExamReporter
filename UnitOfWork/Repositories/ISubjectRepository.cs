using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories;

public interface ISubjectRepository
{
    void InsertNewSubject(Subject subject);
    int GetSubjectIdBySubjectName(string name);
}