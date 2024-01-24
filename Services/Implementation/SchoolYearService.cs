using NationalExamReporter.Entities;
using NationalExamReporter.UnitOfWork.Repositories;
using NationalExamReporter.UnitOfWork.Repositories.Implementation;

namespace NationalExamReporter.Services.Implementation;

public class SchoolYearService:ISchoolYearService
{
    private ISchoolYearRepository? _schoolYearRepository;

    public SchoolYearService()
    {
        InitializeObjects();
    }
    public void InsertSchoolYearIntoSchoolYearTable(int year)
    {
        if (!IsYearExisted(year)) InsertYearIntoSchoolYearTable(year);
    }
    private bool IsYearExisted(int year)
    {
        int schoolYearId = _schoolYearRepository!.GetSchoolYearIdBySchoolYear(year);
        if (schoolYearId == 0) return false;
        return true;
    }

    private void InsertYearIntoSchoolYearTable(int year)
    {
        SchoolYear schoolYear = new SchoolYear()
        {
            Name = $"Exam_Year_{year}",
            ExamYear = year,
            Status = true,
        };
        _schoolYearRepository?.InsertNewSchoolYear(schoolYear);
    }
    private void InitializeObjects()
    {
        _schoolYearRepository = new SchoolYearRepository();
    }

}