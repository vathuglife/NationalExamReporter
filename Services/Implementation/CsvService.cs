using System.IO;
using CsvHelper;
using NationalExamReporter.Mapper;
using NationalExamReporter.Mappers;
using NationalExamReporter.Models;

namespace NationalExamReporter.Services.Implementation
{
    public class CsvService : ICsvService
    {
        
        public List<CsvStudent> ReadCsv(string path)
        {
            List<CsvStudent>? _students;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader,System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Context.RegisterClassMap<StudentMap>();
                _students = csv.GetRecords<CsvStudent>().ToList();
                
            }
            return _students;
        }
        public List<CsvStudentVer2> ReadCsvVer2(string path)
        {
            List<CsvStudentVer2>? _students;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader,System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Context.RegisterClassMap<StudentMapVer2>();
                _students = csv.GetRecords<CsvStudentVer2>().ToList();
                
            }
            return _students;
        }
        
    }
}
