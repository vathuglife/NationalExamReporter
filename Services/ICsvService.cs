using NationalExamReporter.Models;

namespace NationalExamReporter.Services
{
    public interface ICsvService
    {
        List<CsvStudent> ReadCsv(string path);
        List<CsvStudentVer2> ReadCsvVer2(string path);
    }
}
