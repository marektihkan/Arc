using ArcWizard.Core;
using ArcWizard.Infrastructure;
using EnvDTE;
using EnvDTE80;

namespace ArcWizard.Tasks.Projects
{
    public class RemoveProjectTask
    {
        public void RemoveProjectFrom(_DTE application, Project project)
        {
            RemoveProjectFrom(application.Solution as Solution2, project);
        }

        public void RemoveProjectFrom(Solution2 solution, Project project)
        {
            if (solution == null) return;

            Logger.WriteLine("Removing " + project.Name + " from solution");
            
            solution.Remove(project);
            // Give the solution time to release the lock on the project file
            System.Threading.Thread.Sleep(500);
        }

        public void RemoveProjectFrom(Solution solution, Project project)
        {
            RemoveProjectFrom(solution as Solution2, project);
        }

        public void RemoveProjectFrom(SolutionTemplate solution, Project project)
        {
            RemoveProjectFrom(solution.Solution as Solution2, project);
        }
    }
}