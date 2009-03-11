using ArcWizard.Core;
using ArcWizard.Infrastructure;
using ArcWizard.Tasks.IO;

namespace ArcWizard.Tasks.Projects
{
    public class CleanUpTask
    {
        private readonly DeleteDirectoryTask _deleteDirectoryTask = new DeleteDirectoryTask();
        private readonly DeleteFileTask _deleteFileTask = new DeleteFileTask();

        public void RemoveProjectFiles(string projectName, string path)
        {
            Logger.WriteLine("Cleaning up " + projectName);

            _deleteFileTask.DeleteFileFrom(ProjectPathBuilder.CSharpProject(path, projectName));
            _deleteDirectoryTask.Delete(path + "bin");
            _deleteDirectoryTask.Delete(path + "obj");
        }
    }
}