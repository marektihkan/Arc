using ArcWizard.Core;
using ArcWizard.Tasks.Projects;
using EnvDTE;

namespace ArcWizard
{
    public class SourceProjectWizard : BaseWizard
    {
        private MoveProjectTask _moveProjectTask;

        public override void OnStart()
        {
            _moveProjectTask = new MoveProjectTask(Configuration);
        }

        public override void OnProjectGenerated(Project project)
        {
            if (project == null) return;

            var movedProject = _moveProjectTask.MoveTo(project, "\\Source\\", "Source");
            
            movedProject.ProjectItems.AddFromFile(Configuration.RootPath + "\\Source\\CommonAssemblyInfo.cs");
        }
    }
}