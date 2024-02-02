using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface ISchoolYearService
{
    void InsertSchoolYearIntoSchoolYearTable(List<CsvStudentVer2> csvStudents);
}