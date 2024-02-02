using NationalExamReporter.Constants;
using NationalExamReporter.Enums;
using NationalExamReporter.Mappers;
using NationalExamReporter.Models;
using Microsoft.EntityFrameworkCore;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.Services.Implementation;

public class ValedictoriansService : IValedictoriansService
{
    private List<CsvStudentVer2>? _csvStudents;
    private List<ValedictoriansDetails>? _valedictoriansDetails;
    private ValedictoriansBrief? _valedictoriansBrief;

    public ValedictoriansService()
    {
        InitializeObjects();
    }

    public ValedictoriansServiceReturnValue GetValedictoriansDetails(List<CsvStudent> csvStudents)
    {
        // _csvStudents = csvStudents;
        CalculateA00Valedictorian();
        CalculateB00Valedictorian();
        CalculateC00Valedictorian();
        CalculateD00Valedictorian();
        CalculateA01Valedictorian();
        return new ValedictoriansServiceReturnValue()
        {
            ValedictorianDetails = _valedictoriansDetails!,
            ValedictoriansBriefs = GetValedictoriansBrief()!
        };
    }

    public async Task<ValedictoriansServiceReturnValue> GetValedictoriansDetails(
        ValedictoriansParameters parameters) {
        ResetValedictorianDetails();
        SetYearToValedictorianBrief(parameters.year);
        FilterResultByYear(parameters);
        await Task.Run(() =>
        {
            CalculateA00Valedictorian();
            CalculateB00Valedictorian();
            CalculateC00Valedictorian();
            CalculateD00Valedictorian();
            CalculateA01Valedictorian();
        });
        return new ValedictoriansServiceReturnValue()
        {
            ValedictorianDetails = _valedictoriansDetails!,
            ValedictoriansBriefs = GetValedictoriansBrief()!
        };
    }

    public int[] GetYears()
    {
        List<KeyValuePair<string, int>> years = NationalExamConstants.Years;
        int[] result = new int[years.Count];
        for (int index = 0; index < years.Count; index++)
        {
            KeyValuePair<string, int> year = years[index];
            result[index] = year.Value;
        }

        return result;
    }

    private void FilterResultByYear(ValedictoriansParameters parameters)
    {
        int year = parameters.year;
        var csvStudentGroups = parameters.CsvStudents.GroupBy(student=>student.Year);
        var groupByYear = csvStudentGroups.FirstOrDefault(group => group.Key == year);
        _csvStudents = groupByYear!.ToList();
    }
    private void SetYearToValedictorianBrief(int year)
    {
        _valedictoriansBrief.Year = Convert.ToString(year);
    }

    private void ResetValedictorianDetails()
    {
        _valedictoriansDetails!.Clear();
    }
    private void CalculateA00Valedictorian()
    {
        CsvStudent a00TopCsvStudent = _csvStudents!
            .OrderByDescending(student => student.Mathematics + student.Physics + student.Chemistry)!
            .FirstOrDefault()!;

        string? a00ExamGroup = ExamGroup.A00.ToString();
        AutoMapper.Mapper mapper =
            new AutoMapper.Mapper(ValedictoriansDetailsMap.GetA00MapperConfig());

        ValedictoriansDetails details = mapper.Map<ValedictoriansDetails>(a00TopCsvStudent);
        details.ComboName = NationalExamConstants.ExamGroups[a00ExamGroup];
        details.ExamGroup = a00ExamGroup;
        double sum = GetSubjectsSum(details);
        details.Sum = sum;
        _valedictoriansDetails!.Add(details);
        _valedictoriansBrief!.A00 = sum;
    }

    private void CalculateB00Valedictorian()
    {
        CsvStudent b00TopCsvStudent = _csvStudents!
            .OrderByDescending(student => student.Mathematics + student.Chemistry + student.Biology)!
            .FirstOrDefault()!;

        string? b00ExamGroup = ExamGroup.B00.ToString();
        AutoMapper.Mapper mapper =
            new AutoMapper.Mapper(ValedictoriansDetailsMap.GetB00MapperConfig());

        ValedictoriansDetails details = mapper.Map<ValedictoriansDetails>(b00TopCsvStudent);
        details.ComboName = NationalExamConstants.ExamGroups[b00ExamGroup];
        details.ExamGroup = b00ExamGroup;
        double sum = GetSubjectsSum(details);
        details.Sum = sum;
        _valedictoriansDetails!.Add(details);
        _valedictoriansBrief!.B00 = sum;
    }

    private void CalculateC00Valedictorian()
    {
        CsvStudent c00TopCsvStudent = _csvStudents!
            .OrderByDescending(student => student.Literature + student.History + student.Geography)!
            .FirstOrDefault()!;

        string? c00ExamGroup = ExamGroup.C00.ToString();
        AutoMapper.Mapper mapper =
            new AutoMapper.Mapper(ValedictoriansDetailsMap.GetC00MapperConfig());

        ValedictoriansDetails details = mapper.Map<ValedictoriansDetails>(c00TopCsvStudent);
        details.ComboName = NationalExamConstants.ExamGroups[c00ExamGroup];
        details.ExamGroup = c00ExamGroup;
        double sum = GetSubjectsSum(details);
        details.Sum = sum;
        _valedictoriansDetails!.Add(details);
        _valedictoriansBrief!.C00 = sum;
    }

    private void CalculateD00Valedictorian()
    {
        CsvStudent d00TopCsvStudent = _csvStudents!
            .OrderByDescending(student => student.Mathematics + student.Literature + student.English)!
            .FirstOrDefault()!;

        string? d00ExamGroup = ExamGroup.D00.ToString();
        AutoMapper.Mapper mapper =
            new AutoMapper.Mapper(ValedictoriansDetailsMap.GetD00MapperConfig());


        ValedictoriansDetails details = mapper.Map<ValedictoriansDetails>(d00TopCsvStudent);
        details.ComboName = NationalExamConstants.ExamGroups[d00ExamGroup];
        details.ExamGroup = d00ExamGroup;
        double sum = GetSubjectsSum(details);
        details.Sum = sum;
        _valedictoriansDetails!.Add(details);
        _valedictoriansBrief!.D00 = sum;
    }

    private void CalculateA01Valedictorian()
    {
        CsvStudent a01TopCsvStudent = _csvStudents!
            .OrderByDescending(student => student.Mathematics + student.Physics + student.English)!
            .FirstOrDefault()!;

        string? a01ExamGroup = ExamGroup.A01.ToString();
        AutoMapper.Mapper mapper =
            new AutoMapper.Mapper(ValedictoriansDetailsMap.GetA01MapperConfig());

        ValedictoriansDetails details = mapper.Map<ValedictoriansDetails>(a01TopCsvStudent);
        details.ComboName = NationalExamConstants.ExamGroups[a01ExamGroup];
        details.ExamGroup = a01ExamGroup;
        double sum = GetSubjectsSum(details);
        details.Sum = sum;
        _valedictoriansDetails!.Add(details);
        _valedictoriansBrief!.A01 = sum;
    }

    private double GetSubjectsSum(ValedictoriansDetails details)
    {
        double? result = details.Subject1 + details.Subject2 + details.Subject3;
        return (double)result!;
    }

    private void InitializeObjects()
    {
        _valedictoriansDetails = new List<ValedictoriansDetails>();
        _valedictoriansBrief = new ValedictoriansBrief();
        _csvStudents = new List<CsvStudentVer2>();
    }

    private List<ValedictoriansBrief> GetValedictoriansBrief()
    {
        return new List<ValedictoriansBrief>()
        {
            _valedictoriansBrief!
        };
    }
}