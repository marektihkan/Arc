using ArcWizard.Tasks.Projects;

namespace ArcWizard.Core
{
    public class FolderWizard : BaseWizard
    {
        public override void OnProjectGenerated(EnvDTE.Project project)
        {
            base.OnProjectGenerated(project);

            var projectName = project.Name;
            var path = Solution.RootPath + "\\" + projectName + "\\";

            new RemoveProjectTask().RemoveProjectFrom(Solution, project);
            new CleanUpTask().RemoveProjectFiles(projectName, path);
        }

    }
}