using NationalExamReporter.Models;

namespace NationalExamReporter.Services.Parameters;

public class ValedictoriansParameters
{
    public List<CsvStudentVer2> CsvStudents { get; set; }
    public int year { get; set; }
}