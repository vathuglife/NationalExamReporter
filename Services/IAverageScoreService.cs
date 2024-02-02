using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface IAverageScoreService
{
    public List<AverageScoreByProvince> GetAverageScoreByProvince(List<CsvStudent> students);
    public List<AverageScoreByProvince> GetAverageScoreByProvinceVer2(List<CsvStudentVer2> students);
}