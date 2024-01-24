namespace NationalExamReporter.Models;

public class CsvStudent
{
    public string? StudentId { get; set; }
    public string? Province { get; set; }
    public double Mathematics { get; set; }
    public double Literature { get; set; }
    public double Physics { get; set; }
    public double Chemistry { get; set; }
    public double Biology { get; set; }
    public double CombinedNaturalSciences { get; set; }
    public double History { get; set; }
    public double Geography { get; set; }
    public double CivicEducation { get; set; }
    public double CombinedSocialSciences { get; set; }
    public double English { get; set; }
}