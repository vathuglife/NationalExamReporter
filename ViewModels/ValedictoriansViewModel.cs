using NationalExamReporter.Models;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Services.Parameters;

namespace NationalExamReporter.ViewModels;

public class ValedictoriansViewModel
{
    private IValedictoriansService _valedictoriansService;

    public ValedictoriansViewModel()
    {
        InitializeObjects();
    }
    public List<ValedictoriansDetails> GetValedictoriansDetails(List<CsvStudent> _csvStudents)
    {
        return _valedictoriansService.GetValedictoriansDetails(_csvStudents);
    }

    private void InitializeObjects()
    {
        _valedictoriansService = new ValedictoriansService();
    }    
}