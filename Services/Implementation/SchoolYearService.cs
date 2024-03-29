﻿using NationalExamReporter.Entities;
using NationalExamReporter.Models;
using NationalExamReporter.UnitOfWork.Repositories;
using NationalExamReporter.UnitOfWork.Repositories.Implementation;

namespace NationalExamReporter.Services.Implementation;

public class SchoolYearService:ISchoolYearService
{
    private ISchoolYearRepository? _schoolYearRepository;

    public SchoolYearService()
    {
        InitializeObjects();
    }
    public void InsertSchoolYearIntoSchoolYearTable(List<CsvStudentVer2> csvStudents)
    {
        List<int> years = csvStudents.Select(csvStudent => csvStudent.Year).Distinct().ToList();
        foreach (int year in years)
        {
            SchoolYear schoolYear = new SchoolYear()
            {
                Name = $"Exam_Year_{year}",
                ExamYear = year,
                Status = true,
            };
            _schoolYearRepository?.InsertNewSchoolYear(schoolYear);    
        }
        
    }
    private bool IsYearExisted(int year)
    {
        int schoolYearId = _schoolYearRepository!.GetSchoolYearIdBySchoolYear(year);
        if (schoolYearId == 0) return false;
        return true;
    }

    // private void InsertYearIntoSchoolYearTable(List<CsvStudentVer2> csvStudents)
    // {
    //    
    //     _schoolYearRepository?.InsertNewSchoolYear(csvStudents);
    // }
    private void InitializeObjects()
    {
        _schoolYearRepository = new SchoolYearRepository();
    }

}