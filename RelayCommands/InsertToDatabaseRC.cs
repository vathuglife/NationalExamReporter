using System.Windows.Input;

namespace NationalExamReporter.RelayCommands;

public class InsertToDatabaseRC : ICommand
{
    private Action _execute;

    public InsertToDatabaseRC(Action execute)
    {
        _execute = execute;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _execute?.Invoke();
    }

    public event EventHandler? CanExecuteChanged;
}