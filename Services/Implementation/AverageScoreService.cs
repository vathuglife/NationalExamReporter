using NationalExamReporter.Models;

namespace NationalExamReporter.Services.Implementation;

public class AverageScoreService : IAverageScoreService
{
    private List<AverageScoreByProvince>? _averageScoreByProvinces;
    private List<Student>? _students;


    public AverageScoreService()
    {
        InitializeObjects();
    }


    public List<AverageScoreByProvince> GetAverageScoreByProvince(List<Student> students)
    {
        _students = students;
        return GetAverageScoresGroupByProvinces();
    }

    private void InitializeObjects()
    {
        _averageScoreByProvinces = new List<AverageScoreByProvince>();
    }


    private List<AverageScoreByProvince> GetAverageScoresGroupByProvinces()
    {
        return _students!
            .GroupBy(student => GetProvinceCode(student.StudentId!))
            .OrderByDescending(group => group.Average(student => student.Mathematics))
            .ToList()
            .Select(group => new AverageScoreByProvince()
            {
                Province = group.First().Province,
                AverageMath = group.First().Mathematics,
                AverageEnglish = group.Average(student => student.English)
            }).ToList();
    }

    private string GetProvinceCode(string studentId)
    {
        return studentId.Substring(0, 2);
    }
}