namespace NationalExamReporter.Models;

public class TotalScoresByYearsServiceReturnValue
{
    public List<TotalScoresByYears> TotalScoresByYears { get; set; }
    public List<CsvStudentVer2> CsvStudents { get; set; }
}