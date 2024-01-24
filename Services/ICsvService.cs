using NationalExamReporter.Models;

namespace NationalExamReporter.Services
{
    public interface ICsvService
    {
        List<CsvStudent> ReadCsv(string path);       
    }
}
