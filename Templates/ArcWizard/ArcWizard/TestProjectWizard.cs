using ArcWizard.Core;
using ArcWizard.Tasks.Projects;
using EnvDTE;

namespace ArcWizard
{
    public class TestProjectWizard : BaseWizard
    {
        private MoveProjectTask _moveProjectTask;

        public override void OnStart()
        {
            _moveProjectTask = new MoveProjectTask(Configuration);
        }

        public override void OnProjectGenerated(Project project)
        {
            if (project == null) return;

            var movedProject = _moveProjectTask.MoveTo(project, "\\Tests\\", "Tests");

            if (Solution.ShouldNHibernateConfiguration(movedProject.Name))
            {
                new AddNHibernateConfigurationTask().AddConfigurationLinkTo(movedProject, Configuration.RootPath);
            }
        }
    }
}