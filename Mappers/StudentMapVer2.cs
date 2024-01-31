using CsvHelper.Configuration;
using NationalExamReporter.Models;

namespace NationalExamReporter.Mappers;

public class StudentMapVer2: ClassMap<CsvStudentVer2>
{
    public StudentMapVer2()
    {
        InitializeStudentMap();
    }

    private void InitializeStudentMap()
    {
        Map(m => m.StudentId).Name("SBD");
        Map(m => m.Mathematics).Name("Toan").Default(0.0);
        Map(m => m.Literature).Name("Van").Default(0.0);
        Map(m => m.Physics).Name("Ly").Default(0.0);
        Map(m => m.Chemistry).Name("Hoa").Default(0.0);
        Map(m => m.Biology).Name("Sinh").Default(0.0);
        Map(m => m.History).Name("Lich su").Default(0.0);
        Map(m => m.Geography).Name("Dia ly").Default(0.0);
        Map(m => m.CivicEducation).Name("GDCD").Default(0.0);
        Map(m => m.English).Name("Ngoai ngu").Default(0.0);
        Map(m => m.Year).Name("Year").Default(0);
    }
}