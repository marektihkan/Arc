using System.IO;
using ArcWizard.Infrastructure;

namespace ArcWizard.Tasks.IO
{
    public class MoveDirectoryTask
    {
        public void Move(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(sourcePath)) return;

            Logger.WriteLine("Moving project from " + sourcePath + " to target location at " + destinationPath);
            Directory.Move(sourcePath, destinationPath);
        }
    }
}