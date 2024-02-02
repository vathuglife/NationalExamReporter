using NationalExamReporter.Models;

namespace NationalExamReporter.ViewModels.Parameters;

public class InsertStudentDataParameters
{
    public List<CsvStudentVer2> CsvStudents;
    public int Year;
}