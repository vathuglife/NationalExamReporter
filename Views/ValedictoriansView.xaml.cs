using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NationalExamReporter.Models;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.ViewModels;

namespace NationalExamReporter.Views
{
    public partial class ValedictoriansView : Window
    {
        private ValedictoriansViewModel? _viewModel;
        private int[] _years;
        
       
        private ValedictoriansServiceReturnValue _returnValue;
        private int _selectedYear;
        private List<CsvStudentVer2>? _csvStudents;
        public ValedictoriansView(List<CsvStudentVer2> csvStudents)
        {
            InitializeComponent();
            InitializeObjects();
            _csvStudents = csvStudents;
        }

        private async void RefreshValedictorians(object sender, RoutedEventArgs e)
        {;
            SearchBtn.IsEnabled = false;
            _returnValue = await _viewModel!.GetValedictoriansDetails(GetValedictoriansParameters());
            await SetValedictorianValuesToDataGrid();
        }

        private void InitializeObjects()
        {
            _viewModel = new ValedictoriansViewModel();
            _years = _viewModel.GetYearComboBoxValues();
            YearComboBox.ItemsSource = _years;
           
        }

        private ValedictoriansParameters GetValedictoriansParameters()
        {
            return new ValedictoriansParameters()
            {   
                year = _selectedYear,
                CsvStudents = _csvStudents!
            };
        }

        private void HandleYearChanged(object sender, RoutedEventArgs e)
        {
            _selectedYear = Convert.ToInt32(YearComboBox.SelectedItem);
        }

        private async Task SetValedictorianValuesToDataGrid()
        {
            await Dispatcher.InvokeAsync(() =>
            {
                ClearValedictorianValues();
                ValedictoriansDetailsDataGrid.ItemsSource = _returnValue.ValedictorianDetails;
                ValedictoriansBriefDataGrid.ItemsSource = _returnValue.ValedictoriansBriefs;
                SearchBtn.IsEnabled = true;
            });
        }

        private void ClearValedictorianValues()
        {
            ValedictoriansDetailsDataGrid.ItemsSource = null;
            ValedictoriansBriefDataGrid.ItemsSource = null;
        }

      
    }
}