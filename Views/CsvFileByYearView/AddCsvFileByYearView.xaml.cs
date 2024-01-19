using System.Windows;
using NationalExamReporter.Constants;
using NationalExamReporter.Enums;
using NationalExamReporter.Models;
using NationalExamReporter.Utils;
using NationalExamReporter.ViewModels.CsvFileByYearViewModel;

namespace NationalExamReporter.Views.CsvFileByYearView;

public partial class AddCsvFileByYearView : Window
{
    private string? _csvPath;
    private int _year;
    private AddCsvFileByYearViewModel? _addCsvFileByYearViewModel;
    private MainView? _mainView;

    public AddCsvFileByYearView(MainView mainView)
    {
        InitializeComponent();
        InitializeObjects();
        LoadYearsComboBox();
        _mainView = mainView;
    }

    private void InitializeObjects()
    {
        _addCsvFileByYearViewModel = new AddCsvFileByYearViewModel();
    }

    private void LoadYearsComboBox()
    {
        YearComboBox.Items.Clear();
        YearComboBox.SelectedValuePath = "Value";
        YearComboBox.DisplayMemberPath = "Key";
        List<KeyValuePair<string, int>> yearKeyValues = NationalExamConstants.years;
        foreach (KeyValuePair<string, int> yearKeyValue in yearKeyValues)
        {
            YearComboBox.Items.Add(yearKeyValue);
        }
    }

    private void FinishImportCsv(object sender, RoutedEventArgs e)
    {
        GetSelectedYear();
        CsvFileByYear csvFileByYear = new CsvFileByYear()
        {
            Year = _year,
            CsvPath = _csvPath
        };
        CsvFileByYearServiceResult result = _addCsvFileByYearViewModel!.FinishImportCsv(csvFileByYear);
        HandleCsvByYearServiceResultUsingMessageBox(result);
        _mainView!.RefreshYearComboBox();
    }

    private void GetCsvPath(object sender, RoutedEventArgs e)
    {
        _csvPath = _addCsvFileByYearViewModel!.GetCsvFilePath();
        CsvFilePathTextBox.Text = _csvPath;
    }

    private void GetSelectedYear()
    {
        KeyValuePair<string, int> selectedDateTime = (KeyValuePair<string, int>)YearComboBox.SelectedItem;
        _year = selectedDateTime!.Value;
    }

    private void HandleCsvByYearServiceResultUsingMessageBox(CsvFileByYearServiceResult result)
    {
        if (result.Equals(CsvFileByYearServiceResult.SUCCESS))
        {
            ShowImportCsvSuccessMessage();
        }
        else if (result.Equals(CsvFileByYearServiceResult.DUPLICATED))

        {
            ShowImportCsvDuplicatedMessage();
        }
    }

    private void ShowImportCsvSuccessMessage()
    {
        DefaultMessageBoxArguments defaultMessageBoxArguments =
            new DefaultMessageBoxArguments(
                "Successfully imported CSV of the selected year.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information
            );
        MessageBoxUtils.ShowDefaultMessageBox(defaultMessageBoxArguments);
    }

    private void ShowImportCsvDuplicatedMessage()
    {
        DefaultMessageBoxArguments defaultMessageBoxArguments =
            new DefaultMessageBoxArguments(
                "Another CSV of the same year was imported. Try again with a different one.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error
            );
        MessageBoxUtils.ShowDefaultMessageBox(defaultMessageBoxArguments);
    }
}