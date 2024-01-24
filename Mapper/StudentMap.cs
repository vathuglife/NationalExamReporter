using CsvHelper.Configuration;
using NationalExamReporter.Models;

namespace NationalExamReporter.Mapper;

public class StudentMap : ClassMap<CsvStudent>
{
    public StudentMap()
    {
        InitializeStudentMap();
    }

    private void InitializeStudentMap()
    {
        Map(m => m.StudentId).Name("student_id");
        Map(m => m.Province).Name("province");
        Map(m => m.Mathematics).Name("mathematics").Default(0.0);
        Map(m => m.Literature).Name("literature").Default(0.0);
        Map(m => m.Physics).Name("physics").Default(0.0);
        Map(m => m.Chemistry).Name("chemistry").Default(0.0);
        Map(m => m.CombinedNaturalSciences).Name("combined_natural_sciences").Default(0.0);
        Map(m => m.History).Name("history").Default(0.0);
        Map(m => m.Geography).Name("geography").Default(0.0);
        Map(m => m.CivicEducation).Name("civic_education").Default(0.0);
        Map(m => m.CombinedSocialSciences).Name("combined_social_sciences").Default(0.0);
        Map(m => m.English).Name("english").Default(0.0);
    }
}