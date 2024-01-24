using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories.Implementation;

public class SchoolYearRepository : ISchoolYearRepository
{
    private NationalExamReporterDBContext? _dbContext;

    public SchoolYearRepository()
    {
        InitializeObjects();
    }

    public void InsertNewSchoolYear(SchoolYear schoolYear)
    {
        _dbContext?.SchoolYears?.Add(schoolYear);
        _dbContext?.SaveChanges();
    }

    public int GetSchoolYearIdBySchoolYear(int year)
    {
        SchoolYear schoolYear = _dbContext?.SchoolYears!
            .Where(schoolYear => schoolYear.ExamYear == year)!.First()!;
        return schoolYear.Id;
    }

    private void InitializeObjects()
    {
        _dbContext = new NationalExamReporterDBContext();
    }
}