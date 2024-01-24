using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories;

public interface ISchoolYearRepository
{
    void InsertNewSchoolYear(SchoolYear schoolYear);
    int GetSchoolYearIdBySchoolYear(int year);
}