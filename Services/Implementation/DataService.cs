using NationalExamReporter.Entities;
using NationalExamReporter.Enums;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services.Implementation;

public class DataService:IDataService
{
    private ISchoolYearService? _schoolYearService;
    private IStudentService? _studentService;
    

    public DataService()
    {
        InitializeObjects();
    }
    public DataServiceResult InsertIntoDatabase(List<CsvStudent> csvStudents,int year)
    {
        _schoolYearService!.InsertSchoolYearIntoSchoolYearTable(year);
        _studentService!.InsertStudentsData(new StudentServiceParameters()
        {
            Year = year,
            CsvStudents = csvStudents
        });
        return DataServiceResult.SUCCESS;
    }
    private void InitializeObjects()
    {
        _schoolYearService = new SchoolYearService();
        _studentService = new StudentService();
    }
}