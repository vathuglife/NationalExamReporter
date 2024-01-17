using System.Windows;
using NationalExamReporter.Constants;
using NationalExamReporter.Models;
using NationalExamReporter.ViewModels;

namespace NationalExamReporter.Views;

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
        List<KeyValuePair<string,int>> yearKeyValues = NationalExamConstants.years;
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
        _addCsvFileByYearViewModel!.FinishImportCsv(csvFileByYear);
        _mainView!.RefreshYearComboBox();
    }

    private void GetCsvPath(object sender, RoutedEventArgs e)
    {
        _csvPath = _addCsvFileByYearViewModel!.GetCsvFilePath();
        CsvFilePathTextBox.Text = _csvPath;
    }

    private void GetSelectedYear()
    {
        KeyValuePair<string,int> selectedDateTime = (KeyValuePair<string,int>)YearComboBox.SelectedItem;
        _year = selectedDateTime!.Value;
    }
}