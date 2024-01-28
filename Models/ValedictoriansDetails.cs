using NationalExamReporter.Enums;

namespace NationalExamReporter.Models;

public class ValedictoriansDetails
{
    public string? ExamGroup { get; set; }
    public string? ExamCode{ get; set; }
    public string? Province{ get; set; }
    public double? Subject1{ get; set; }
    public double? Subject2{ get; set; }
    public double? Subject3{ get; set; }
    public double? Sum{ get; set; }
    public string? ComboName{ get; set; }

}