using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface IAverageScoreService
{
    public List<AverageScoreByProvince> GetAverageScoreByProvince(List<Student> students);
}