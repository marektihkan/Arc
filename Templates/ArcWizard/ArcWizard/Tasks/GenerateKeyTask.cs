using ArcWizard.Core;
using ArcWizard.Infrastructure;

namespace ArcWizard.Tasks
{
    public class GenerateKeyTask
    {
        private readonly string _generatorPath;


        public GenerateKeyTask(string generatorPath)
        {
            _generatorPath = generatorPath + "sn.exe";
        }

        public GenerateKeyTask(Configuration configuration) : this(configuration.RootPath + "\\Tools\\Temp\\")
        {
        }

        public void GenerateTo(string path)
        {
            Logger.WriteLine("Creating key to " + _generatorPath);
            var process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = _generatorPath;
            process.StartInfo.Arguments = "-k \"" + path + "\"";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
    }
}