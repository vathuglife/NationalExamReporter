using System.IO;

namespace NationalExamReporter.Constants;

public class ConfigPaths
{
    private static readonly string? WorkingDirectory =
        Directory.GetCurrentDirectory();

    private static readonly string? ProjectDirectory =
        Directory.GetParent(WorkingDirectory)!.Parent!.Parent!.FullName;

    public static readonly string LoadedCsv = Path.Combine(ProjectDirectory, "Configs", "LoadedCsv.json");
    public static readonly string CurrentIndex = Path.Combine(ProjectDirectory, "Configs", "CurrentIndex.json");
    public static readonly string AppSettings = Path.Combine(ProjectDirectory, "appsettings.json");
}