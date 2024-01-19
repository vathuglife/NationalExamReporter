using System.IO;

namespace NationalExamReporter.Constants;

public class ConfigPaths
{
    private static readonly string? WorkingDirectory =
        Directory.GetCurrentDirectory();

    private static readonly string? ProjectDirectory =
        Directory.GetParent(WorkingDirectory)!.Parent!.Parent!.FullName;

    public static readonly string LoadedCsv = Path.Combine(ProjectDirectory, "Configs", "loadedCsv.json");
    public static readonly string AppSettings = Path.Combine(ProjectDirectory, "appsettings.json");
}