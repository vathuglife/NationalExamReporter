using NationalExamReporter.Enums;
using NationalExamReporter.Models;

namespace NationalExamReporter.Services;

public interface IDataService
{
    DataServiceResult InsertIntoDatabase(List<CsvStudent> csvStudents,int year);
}