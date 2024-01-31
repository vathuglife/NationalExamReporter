﻿using System.Windows;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.Utils;
using NationalExamReporter.ViewModels;
using NationalExamReporter.ViewModels.Parameters;
using NationalExamReporter.Views.CsvFileByYearView;


namespace NationalExamReporter.Views
{
    public partial class MainView
    {
        private MainViewModel? _mainViewModel;
        private List<CsvStudent>? _csvStudents;
        private string? _csvPath;
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
                ClearStudentsDataGrid();
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
            try
            {
                if (!IsStudentDataLoaded())
                {
                    ShowCsvFileNotLoadedMessage();
                    return;
                }

                AverageScoreByProvinceView averageScoreByProvinceWindow =
                    new AverageScoreByProvinceView(_mainViewModel!.GetAverageScoreByProvince(_csvStudents!));
                averageScoreByProvinceWindow.Show();
            }
            catch (Exception error)
            {
                ShowError(error);
            }
        }


        private void HandleYearChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                _selectedCsvFileByYear = (CsvFileByYear)YearComboBox.SelectedItem;
                _csvPath = _selectedCsvFileByYear.CsvPath;
                HandleLoadButton();
            }
            catch (Exception error)
            {
                ShowError(error);
            }
            
        }

        private async void LoadCsvFromSelectedYear(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCsvFromSelectedYearButton.IsEnabled = false;
                _csvStudents = await _mainViewModel!.GetStudentsCsvData(_csvPath!);
                await UpdateCsvStudentsToDataGrid();
            }
            catch (Exception error)
            {
                ShowError(error);
            }
        }

        private async Task UpdateCsvStudentsToDataGrid()
        {
            await Dispatcher.InvokeAsync(() =>
            {
                LoadCsvFromSelectedYearButton.IsEnabled = true;
                StudentsDataGrid.ItemsSource = _csvStudents;
                SetCsvPathToCsvFileTextBox();
                if (DoesUserWantToInsertStudentDataToDb())
                {
                    InsertStudentDataToDatabase();
                }
            });

        }

        private void ShowValedictorians(object sender, RoutedEventArgs e)
        {
            try
            {
                ValedictoriansView valedictoriansView = new ValedictoriansView();
                valedictoriansView.Show();
            }
            catch (Exception error)
            {
                ShowError(error);
            }
        }

        private void InsertStudentDataToDatabase()
        {
            InsertToDatabaseProgressView progressView = new InsertToDatabaseProgressView(
                new InsertStudentDataParameters()
                {
                    CsvStudents = _csvStudents!,
                    Year = _selectedCsvFileByYear!.Year
                });
            progressView.Show();
        }
        private void HandleLoadButton()
        {
            if (_selectedCsvFileByYear!=null)
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
            
        }
        
        private void DisableLoadCsvByYearButton()
        {
            LoadCsvFromSelectedYearButton.IsEnabled = false;
            
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

        private void ClearStudentsDataGrid()
        {
            StudentsDataGrid.ItemsSource = null;
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
                && !ListUtils.IsListNullOrEmpty(_csvStudents!))
                return true;
            return false;
        }

        private bool DoesUserWantToInsertStudentDataToDb()
        {
            DefaultMessageBoxArguments defaultMessageBoxArguments =
                new DefaultMessageBoxArguments(
                    "Do you want to insert the student data to DB?", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information
                );
            MessageBoxResult result = MessageBoxUtils.GetYesNoMessageBoxResult(defaultMessageBoxArguments);
            if (result == MessageBoxResult.Yes) return true;
            return false;
        }
    }
}