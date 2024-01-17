using System.IO;
using CsvHelper;
using NationalExamReporter.Mapper;
using NationalExamReporter.Models;

namespace NationalExamReporter.Services.Implementation
{
    public class CsvService : ICsvService
    {
        private List<Student>? _students;
        public List<Student> ReadCsv(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader,System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Context.RegisterClassMap<StudentMap>();
                _students = csv.GetRecords<Student>().ToList();
                
            }
            return _students;
        }
        
    }
}
