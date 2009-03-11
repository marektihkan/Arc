using System.IO;
using ArcWizard.Infrastructure;

namespace ArcWizard.Tasks.IO
{
    public class DeleteFileTask
    {
        public void DeleteFileFrom(string path)
        {
            if (!File.Exists(path)) return;
            
            Logger.WriteLine("Deleting file " + path);
            File.Delete(path);
        }
    }
}