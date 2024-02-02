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
        
        private ITotalScoreByYearsService _totalScoreByYearsService;
        public MainViewModel()
        {
            InitializeObjects();
        }

        

        public List<CsvFileByYear> GetLoadedCsvInJson()
        {
            return JsonUtils.DeserializeObjectList<CsvFileByYear>(ConfigPaths.LoadedCsv);
        }
        // public Task<List<CsvStudent>> GetStudentsCsvData(string csvPath)
        // {
        //     return Task.Run(()=>_csvService!.ReadCsv(csvPath));
        // }
        public Task<TotalScoresByYearsServiceReturnValue> GetStudentsCsvDataVer2(string csvPath)
        {
            return Task.Run(()=>_totalScoreByYearsService.GetTotalScoresByYears(csvPath));
        }
        // public List<AverageScoreByProvince> GetAverageScoreByProvince(List<CsvStudent> students)
        // {
        //     return _averageScoreService!.GetAverageScoreByProvince(students);
        // }
        // public List<AverageScoreByProvince> GetAverageScoreByProvinceVer2(List<CsvStudentVer2> students)
        // {
        //     return _averageScoreService!.GetAverageScoreByProvinceVer2(students);
        // }

        private void InitializeObjects()
        {
            _totalScoreByYearsService = new TotalScoresByYearsService();
        }
          
    }
}