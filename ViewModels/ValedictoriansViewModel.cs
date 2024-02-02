using NationalExamReporter.Models;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.Views;

namespace NationalExamReporter.ViewModels;

public class ValedictoriansViewModel
{
    private IValedictoriansService? _valedictoriansService;

    public ValedictoriansViewModel()
    {
        InitializeObjects();
    }
    public Task<ValedictoriansServiceReturnValue> GetValedictoriansDetails(ValedictoriansParameters parameters)
    {
        return Task.Run(()=> _valedictoriansService!.GetValedictoriansDetails(parameters));
        
    }

    public int[] GetYearComboBoxValues()
    {
        return _valedictoriansService.GetYears();
    }
    private void InitializeObjects()
    {
        _valedictoriansService = new ValedictoriansService();
    }    
}