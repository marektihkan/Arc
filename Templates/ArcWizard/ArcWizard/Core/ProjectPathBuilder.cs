namespace ArcWizard.Core
{
    public class ProjectPathBuilder
    {
        public static string CSharpProject(string directoryPath, string projectName)
        {
            return directoryPath + "\\" + projectName + ".csproj";
        }
    }
}