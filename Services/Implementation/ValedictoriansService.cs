using NationalExamReporter.Constants;
using NationalExamReporter.Enums;
using NationalExamReporter.Mapper;
using NationalExamReporter.Mappers;
using NationalExamReporter.Models;

namespace NationalExamReporter.Services.Implementation;

public class ValedictoriansService:IValedictoriansService
{
    private List<CsvStudent>? _csvStudents;
    private List<ValedictoriansDetails>? _valedictoriansDetails;

    public ValedictoriansService()
    {
        InitializeObjects();
    }
    public List<ValedictoriansDetails> GetValedictoriansDetails(List<CsvStudent> csvStudents)
    {
        _csvStudents = csvStudents;
        CalculateA00Valedictorian();
        CalculateB00Valedictorian();
        CalculateC00Valedictorian();
        CalculateD00Valedictorian();
        CalculateA01Valedictorian();
        return _valedictoriansDetails!;
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
        details.Sum = GetSubjectsSum(details);
        _valedictoriansDetails!.Add(details);
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
        details.Sum = GetSubjectsSum(details);
        _valedictoriansDetails!.Add(details);
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
        details.Sum = GetSubjectsSum(details);
        _valedictoriansDetails!.Add(details);
    }

    private void CalculateD00Valedictorian()
    {
        CsvStudent d00TopCsvStudent = _csvStudents!
            .OrderByDescending(student => student.Literature + student.History + student.Geography)!
            .FirstOrDefault()!;

        string? d00ExamGroup = ExamGroup.D00.ToString();
        AutoMapper.Mapper mapper = 
            new AutoMapper.Mapper(ValedictoriansDetailsMap.GetD00MapperConfig());
        
        ValedictoriansDetails details = mapper.Map<ValedictoriansDetails>(d00TopCsvStudent);
        details.ComboName = NationalExamConstants.ExamGroups[d00ExamGroup];
        details.ExamGroup = d00ExamGroup;
        details.Sum = GetSubjectsSum(details);
        _valedictoriansDetails!.Add(details);
    }
    private void CalculateA01Valedictorian()
    {
        CsvStudent a01TopCsvStudent = _csvStudents!
            .OrderByDescending(student => student.Literature + student.History + student.Geography)!
            .FirstOrDefault()!;

        string? a01ExamGroup = ExamGroup.A01.ToString();
        AutoMapper.Mapper mapper = 
            new AutoMapper.Mapper(ValedictoriansDetailsMap.GetA01MapperConfig());
        
        ValedictoriansDetails details = mapper.Map<ValedictoriansDetails>(a01TopCsvStudent);
        details.ComboName = NationalExamConstants.ExamGroups[a01ExamGroup];
        details.ExamGroup = a01ExamGroup;
        details.Sum = GetSubjectsSum(details);
        _valedictoriansDetails!.Add(details);
    }
    private double GetSubjectsSum(ValedictoriansDetails details)
    {
        double? result = details.Subject1 + details.Subject2 + details.Subject3;
        return (double)result!;
    }
    private void InitializeObjects()
    {
        _valedictoriansDetails = new List<ValedictoriansDetails>();
    }
}