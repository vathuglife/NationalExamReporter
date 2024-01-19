using System.Windows;
using NationalExamReporter.Models;
using NationalExamReporter.Utils;
using NationalExamReporter.ViewModels;
using NationalExamReporter.Views.CsvFileByYearView;

namespace NationalExamReporter.Views
{
    public partial class MainView
    {
        private MainViewModel? _mainViewModel;
        private List<Student>? _students;
        private string? _csvPath;
        private bool _isLoadButtonEnabled;
        private CsvFileByYear? _selectedCsvFileByYear;

        public MainView()
        {
            InitializeComponent();
            InitializeObjects();
            RefreshYearComboBox();
        }

        public void RefreshYearComboBox()
        {
            List<CsvFileByYear> csvFileByYears = _mainViewModel!.GetLoadedCsvInJson();
            YearComboBox.ItemsSource = csvFileByYears;
            YearComboBox.DisplayMemberPath = "Year";
        }

        private void InitializeObjects()
        {
            _mainViewModel = new MainViewModel();
            _isLoadButtonEnabled = false;
        }

        private void AddCsv(object sender, RoutedEventArgs e)
        {
            try
            {
                AddCsvFileByYearView addCsvFileByYearView = new AddCsvFileByYearView(this);
                addCsvFileByYearView.Show();

                
            }
            catch (Exception error)
            {
                ShowError(error);
            }
        }

        private void DeleteCsv(object sender, RoutedEventArgs e)
        {
            try
            {
                DeleteCsvFileByYearView deleteCsvFileByYearView = new DeleteCsvFileByYearView(this);
                deleteCsvFileByYearView.Show();
            }
            catch (Exception error)
            {
                ShowError(error);
            }
        }

        private void ShowAverageScoreByProvince(object sender, RoutedEventArgs e)
        {
            if (!IsStudentDataLoaded())
            {
                ShowCsvFileNotLoadedMessage();
                return;
            }

            AverageScoreByProvinceView averageScoreByProvinceWindow =
                new AverageScoreByProvinceView(_mainViewModel!.GetAverageScoreByProvince(_students!));
            averageScoreByProvinceWindow.Show();
        }

        
        private void HandleYearChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedCsvFileByYear = (CsvFileByYear)YearComboBox.SelectedItem;
            _csvPath = _selectedCsvFileByYear.CsvPath;
            HandleLoadButton();
        }
        private void LoadCsvFromSelectedYear(object sender, RoutedEventArgs e)
        {
            _students = _mainViewModel!.GetStudentsCsvData(_csvPath!);
            StudentsDataGrid.ItemsSource = _students;
            SetCsvPathToCsvFileTextBox();
        }
        
        private void HandleLoadButton()
        {
            if (!_isLoadButtonEnabled)
            {
                EnableLoadCsvByYearButton();
            }
            else
            {
                DisableLoadCsvByYearButton();
            }
        }

        private void EnableLoadCsvByYearButton()
        {
            LoadCsvFromSelectedYearButton.IsEnabled = true;
            _isLoadButtonEnabled = true;
        }

        private void DisableLoadCsvByYearButton()
        {
            LoadCsvFromSelectedYearButton.IsEnabled = false;
            _isLoadButtonEnabled = false;
        }

        private void ShowError(Exception e)
        {
            DefaultMessageBoxArguments defaultMessageBoxArguments =
                new DefaultMessageBoxArguments(
                    e.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error
                );
            MessageBoxUtils.ShowDefaultMessageBox(defaultMessageBoxArguments);
        }

        private void SetCsvPathToCsvFileTextBox()
        {
            CurrentCsvFileTextBox.Text = _csvPath!;
        }

        private void ShowCsvFileNotLoadedMessage()
        {
            DefaultMessageBoxArguments defaultMessageBoxArguments =
                new DefaultMessageBoxArguments(
                    "You have not loaded a CSV file. Try again.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error
                );
            MessageBoxUtils.ShowDefaultMessageBox(defaultMessageBoxArguments);
        }

        private bool IsStudentDataLoaded()
        {
            if (!String.IsNullOrEmpty(_csvPath)
                && !ListUtils.IsListNullOrEmpty(_students!))
                return true;
            return false;
        }
    }
}