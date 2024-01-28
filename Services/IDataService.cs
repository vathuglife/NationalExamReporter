using System.ComponentModel;
using NationalExamReporter.Enums;
using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface IDataService
{
    void InsertIntoDatabase(List<CsvStudent> csvStudents,int year);
}