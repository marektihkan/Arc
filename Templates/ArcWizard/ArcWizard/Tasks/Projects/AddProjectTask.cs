using System.IO;
using ArcWizard.Infrastructure;
using EnvDTE;
using EnvDTE80;

namespace ArcWizard.Tasks.Projects
{
    public class AddProjectTask
    {
        public Project AddProjectFromFileTo(Solution2 solution, string path)
        {
            if (!File.Exists(path) && solution == null)
                return null;

            Logger.WriteLine("Adding project from " + path + " to solution");
            return solution.AddFromFile(path, false);
        }

        public Project AddProjectFromFileTo(Solution solution, string path)
        {
            return AddProjectFromFileTo(solution as Solution2, path);
        }

        public Project AddProjectFromFileTo(Solution solution, string solutionFolderName, string path)
        {
            return AddProjectFromFileTo(solution as Solution2, solutionFolderName, path);
        }

        public Project AddProjectFromFileTo(Solution2 solution, string solutionFolderName, string path)
        {
            if (!File.Exists(path) && solution == null)
                return null;

            var solutionFolder = FindSolutionFolderByName(solution, solutionFolderName) ??
                                 solution.AddSolutionFolder(solutionFolderName).Object as SolutionFolder;

            if (solutionFolder == null)
                return null;

            Logger.WriteLine("Adding project from " + path + " to solution folder " + solutionFolderName);
            return solutionFolder.AddFromFile(path);
        }

        private SolutionFolder FindSolutionFolderByName(Solution2 solution, string solutionFolderName)
        {
            foreach (Project project in solution.Projects)
            {
                if (project.Name == solutionFolderName)
                    return project.Object as SolutionFolder;
            }
            return null;
        }
    }
}