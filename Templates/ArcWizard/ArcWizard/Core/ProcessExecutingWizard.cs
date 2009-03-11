using ArcWizard.Tasks.IO;
using ArcWizard.Tasks.Projects;

namespace ArcWizard.Core
{
    /// <summary>
    /// After executing project and wizard, the project and its files will be deleted. 
    /// </summary>
    public class ProcessExecutingWizard : BaseWizard
    {
        public override void ProjectFinishedGenerating(EnvDTE.Project project)
        {
            base.ProjectFinishedGenerating(project);
            
            var projectName = project.Name;
            new RemoveProjectTask().RemoveProjectFrom(Solution, project);
            new DeleteDirectoryTask().Delete(Solution.RootPath + "\\" + projectName);
        }

    }
}