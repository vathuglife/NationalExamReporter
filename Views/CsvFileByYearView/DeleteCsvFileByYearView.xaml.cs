using System.Text;
using System.Windows;
using NationalExamReporter.Enums;
using NationalExamReporter.Models;
using NationalExamReporter.Utils;
using NationalExamReporter.ViewModels.CsvFileByYearViewModel;

namespace NationalExamReporter.Views.CsvFileByYearView
{
    public partial class DeleteCsvFileByYearView
    {
        private DeleteCsvFileByYearViewModel? _deleteCsvFileByYearViewModel;
        private MainView? _mainView;
        public DeleteCsvFileByYearView(MainView mainView)
        {
            InitializeComponent();
            InitializeObjects();
            RefreshCsvDataGrid();
            _mainView = mainView;
        }

        private void InitializeObjects()
        {
            _deleteCsvFileByYearViewModel = new DeleteCsvFileByYearViewModel();
        }

        private void DeleteCsv(object sender, RoutedEventArgs e)
        {
            if (!IsDeleteCsvOkay()) return;
            int selectedCsvFileByYearIndex = GetIndexOfSelectedEntry();
            CsvFileByYearServiceResult result =
                _deleteCsvFileByYearViewModel!.DeleteCsvFromLoadedCsv(selectedCsvFileByYearIndex);
            HandleCsvServiceResultUsingMessageBox(result);
            RefreshCsvDataGrid();
            _mainView!.RefreshYearComboBox();
        }

        private void RefreshCsvDataGrid()
        {
            LoadedCsvDataGrid.ItemsSource = null;
            LoadedCsvDataGrid.ItemsSource = _deleteCsvFileByYearViewModel!.GetCsvFileByYears();
        }

        private int GetIndexOfSelectedEntry()
        {
            return LoadedCsvDataGrid.SelectedIndex;
        }

        private bool IsDeleteCsvOkay()
        {
            DefaultMessageBoxArguments defaultMessageBoxArguments =
                new DefaultMessageBoxArguments(
                    "Do you really want to delete this CSV?", "Warning",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning
                );
            if (MessageBoxUtils.GetYesNoMessageBoxResult(defaultMessageBoxArguments)
                ==MessageBoxResult.Yes)
                return true;
            return false;
        }

        private void HandleCsvServiceResultUsingMessageBox(CsvFileByYearServiceResult result)
        {
            if (result == CsvFileByYearServiceResult.SUCCESS)
            {
                ShowDeleteCsvSuccessfulMessage();
            }
            else
            {
                ShowDeleteCsvFailureMessage();
            }
        }

        private void ShowDeleteCsvSuccessfulMessage()
        {
            DefaultMessageBoxArguments defaultMessageBoxArguments =
                new DefaultMessageBoxArguments(
                    "Successfully deleted the CSV file", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information
                );
            MessageBoxUtils.ShowDefaultMessageBox(defaultMessageBoxArguments);
        }

        private void ShowDeleteCsvFailureMessage()
        {
            DefaultMessageBoxArguments defaultMessageBoxArguments =
                new DefaultMessageBoxArguments(
                    "Unable to delete CSV file", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error
                );
            MessageBoxUtils.ShowDefaultMessageBox(defaultMessageBoxArguments);
        }
    }
}