using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NationalExamReporter.Models;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.ViewModels.Parameters;

namespace NationalExamReporter.ViewModels;

public class InsertToDatabaseProgressViewModel:INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public int Progress
    {
        get => _progress;
        set
        {
            if (_progress != value)
            {
                _progress = value;
                RaisePropertyChanged(nameof(Progress));
            }
        }
    }

    public string ProgressTxt
    {
        get => _progressTxt; 
        set
        {
            if (_progressTxt != value)
            {
                _progressTxt = value;
                RaisePropertyChanged(nameof(ProgressTxt));
            }
        }
    }

    private int _progress;
    private string? _progressTxt;
    private int _year;
    private List<CsvStudentVer2>? _csvStudents;
    private IStudentService? _studentService;
    private ISchoolYearService? _schoolYearService;
    
    public InsertToDatabaseProgressViewModel(InsertStudentDataParameters parameters)
    {
        InitializeObjects();
        AssignValuesToPrivateMembers(parameters);
    }
    public void InsertStudentData()
    {
        // _schoolYearService!.InsertSchoolYearIntoSchoolYearTable(_csvStudents!);
        _studentService!.InsertStudentsData(new StudentServiceParameters()
        {
            Year = _year,
            CsvStudents = _csvStudents
        });
        
    }

    private void InitializeObjects()
    {
        _schoolYearService = new SchoolYearService();
        _studentService = new StudentService();
        _studentService.ProgressChanged += StudentService_ProgressChanged!;
    }
 
    private void StudentService_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Debug.WriteLine($"VIEW_MODEL_PROGRESS: {e.ProgressPercentage}");
        Debug.WriteLine($"VIEW_MODEL_PROGRESS_TXT: {e.UserState}");
        Progress = e.ProgressPercentage;
        ProgressTxt = e.UserState!.ToString()!;
    }

    private void AssignValuesToPrivateMembers(InsertStudentDataParameters parameters)
    {
        _year = parameters.Year;
        _csvStudents = parameters.CsvStudents;
    }

    protected virtual void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}