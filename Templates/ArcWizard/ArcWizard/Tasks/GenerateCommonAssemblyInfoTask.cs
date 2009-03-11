using ArcWizard.Core;
using ArcWizard.Infrastructure;

namespace ArcWizard.Tasks
{
    public class GenerateCommonAssemblyInfoTask
    {
        private readonly string _buildFilePath;
        private readonly string _rootPath;
        private readonly string _generatorPath;


        public GenerateCommonAssemblyInfoTask(string generatorPath, string buildFilePath, string rootPath)
        {
            _buildFilePath = buildFilePath;
            _rootPath = rootPath;
            _generatorPath = generatorPath + "nant.exe";
        }

        public GenerateCommonAssemblyInfoTask(Configuration configuration)
            : this(configuration.RootPath + "\\Tools\\NAnt\\bin\\", 
            configuration.RootPath + "\\Configuration\\Build\\Default.build",
            configuration.RootPath)
        {
        }

        public void Generate()
        {
            Logger.WriteLine("Generating CommonAssemblyInfo");
            var process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = _generatorPath;
            process.StartInfo.Arguments = "-buildfile:\"" + _buildFilePath + "\" -D:project.root.path=\"" + _rootPath + "\" Version";
            process.Start();
            process.WaitForExit();
        }
    }
}