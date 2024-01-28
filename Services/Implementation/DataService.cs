using System.ComponentModel;
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
    

    public event EventHandler<ProgressChangedEventArgs>? ProgressChanged;

    public void InsertIntoDatabase(List<CsvStudent> csvStudents,int year)
    {
        _schoolYearService!.InsertSchoolYearIntoSchoolYearTable(year);
        _studentService!.InsertStudentsData(new StudentServiceParameters()
        {
            Year = year,
            CsvStudents = csvStudents
        });
    }
    private void InitializeObjects()
    {
        _schoolYearService = new SchoolYearService();
        _studentService = new StudentService();
    }
}