using NationalExamReporter.Models;

namespace NationalExamReporter.Services
{
    public interface ICsvService
    {
        List<Student> ReadCsv(string path);       
    }
}
