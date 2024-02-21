using Galaxon.Core.Files;

namespace Galaxon.ProjectEuler;

public static class Utility
{
    public static string GetDataFilePath(string filename)
    {
        return Path.Combine(DirectoryUtility.GetSolutionDirectory()!, $"ProjectEuler/data/{filename}");
    }
}
