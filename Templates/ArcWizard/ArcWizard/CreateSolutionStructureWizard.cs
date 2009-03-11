using ArcWizard.Core;
using ArcWizard.Infrastructure;
using EnvDTE;

namespace ArcWizard
{
    public class CreateSolutionStructureWizard : ProcessExecutingWizard
    {
        public override void OnStart()
        {
            Logger.Configure(Configuration);
        }

        public override void OnProjectGenerated(Project project)
        {
            Solution.CreateSolutionDirectoryStructure();
        }
    }
}