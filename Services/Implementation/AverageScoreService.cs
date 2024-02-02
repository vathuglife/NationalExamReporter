using NationalExamReporter.Models;

namespace NationalExamReporter.Services.Implementation;

public class AverageScoreService : IAverageScoreService
{
    private List<AverageScoreByProvince>? _averageScoreByProvinces;
    private List<CsvStudent>? _students;
    private List<CsvStudentVer2>? _studentsVer2;


    public AverageScoreService()
    {
        InitializeObjects();
    }


    public List<AverageScoreByProvince> GetAverageScoreByProvince(List<CsvStudent> students)
    {
        _students = students;
        return GetAverageScoresGroupByProvinces();
    }
    public List<AverageScoreByProvince> GetAverageScoreByProvinceVer2(List<CsvStudentVer2> students)
    {
        _studentsVer2 = students;
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