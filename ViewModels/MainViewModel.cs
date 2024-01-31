using NationalExamReporter.Constants;
using NationalExamReporter.Enums;
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
        public Task<List<CsvStudent>> GetStudentsCsvData(string csvPath)
        {
            return Task.Run(()=>_csvService!.ReadCsv(csvPath));
        }

        public List<AverageScoreByProvince> GetAverageScoreByProvince(List<CsvStudent> students)
        {
            return _averageScoreService!.GetAverageScoreByProvince(students);
        }

          
    }
}