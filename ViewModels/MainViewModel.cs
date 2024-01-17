using NationalExamReporter.Constants;
using NationalExamReporter.Models;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Utils;

namespace NationalExamReporter.ViewModels
{
    public class MainViewModel
    {
        private ICsvService? _csvService;
        private IAverageScoreService? _averageScoreService;
        private ICsvFileByYearService? _csvFileByYearService;
        public MainViewModel()
        {
            InitializeObjects();
        }

        private void InitializeObjects()
        {
            _csvService = new CsvService();
            _averageScoreService = new AverageScoreService();
        }

        public List<CsvFileByYear> GetLoadedCsvInJson()
        {
            return JsonUtils.DeserializeObjectList<CsvFileByYear>(ConfigPaths.LoadedCsv);
        }
        public List<Student> GetStudentsCsvData(string csvPath)
        {
            return _csvService!.ReadCsv(csvPath);
        }

        public List<AverageScoreByProvince> GetAverageScoreByProvince(List<Student> students)
        {
            return _averageScoreService!.GetAverageScoreByProvince(students);
        }


        
    }
}