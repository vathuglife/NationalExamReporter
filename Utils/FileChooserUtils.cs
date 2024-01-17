using Microsoft.Win32;

namespace NationalExamReporter.Utils;

public static class FileChooserUtils
{
    private static string _path;
    private static OpenFileDialog _openFileDialog;

    static FileChooserUtils()
    {
        InitializeOpenFileDialog();
    }

    public static string GetFilePath(string filter)
    {
        if (_openFileDialog.ShowDialog() == true)
            _path = _openFileDialog.FileName;
        _openFileDialog.Filter = filter;
        return _path;
    }

    private static void InitializeOpenFileDialog()
    {
        _openFileDialog = new OpenFileDialog();
    }
}