using System.Windows;
using NationalExamReporter.Models;

namespace NationalExamReporter.Views
{
    
    public partial class AverageScoreByProvinceView : Window
    {
        private List<AverageScoreByProvince> _averageScoreByProvinces;
        public AverageScoreByProvinceView(List<AverageScoreByProvince> averageScoreByProvinces)
        {
            InitializeComponent();
            _averageScoreByProvinces = averageScoreByProvinces;
            ClearAverageScoreByProvinceDataGrid();
            ShowAverageScoreByProvinces();
        }

        private void ShowAverageScoreByProvinces()
        {
            AverageScoreByProvinceDataGrid.ItemsSource = _averageScoreByProvinces;
        }

        private void ClearAverageScoreByProvinceDataGrid()
        {
            AverageScoreByProvinceDataGrid.Items.Clear();    
        }
        
    }
}
