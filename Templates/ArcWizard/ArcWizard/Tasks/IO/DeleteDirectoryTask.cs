using System.IO;
using ArcWizard.Infrastructure;

namespace ArcWizard.Tasks.IO
{
    public class DeleteDirectoryTask
    {
        public void Delete(string path)
        {
            if (!Directory.Exists(path)) return;

            Logger.WriteLine("Deleting directory " + path);
            Directory.Delete(path, true);
        }
    }
}