using NationalExamReporter.Models;

namespace NationalExamReporter.ViewModels.Parameters;

public class InsertStudentDataParameters
{
    public List<CsvStudent> CsvStudents;
    public int Year;
}