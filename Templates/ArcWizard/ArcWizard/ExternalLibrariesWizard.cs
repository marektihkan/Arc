using ArcWizard.Core;
using ArcWizard.Tasks.IO;
using ArcWizard.Tasks.Projects;
using EnvDTE;

namespace ArcWizard
{
    public class ExternalLibrariesWizard : BaseWizard
    {
        public override void OnProjectGenerated(Project project)
        {
            var projectName = project.Name;
            new RemoveProjectTask().RemoveProjectFrom(Solution, project);
            new MoveDirectoryTask().Move(Solution.RootPath + "\\ExternalLibraries\\", Solution.RootPath + "\\External Libraries\\");
            new CleanUpTask().RemoveProjectFiles(projectName, Solution.RootPath + "\\External Libraries\\");
        }
    }
}