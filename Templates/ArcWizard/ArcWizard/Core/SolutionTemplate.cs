using System.Collections.Generic;
using System.IO;
using EnvDTE;

namespace ArcWizard.Core
{
    public abstract class SolutionTemplate
    {
        public virtual string RootPath { get; protected set; }

        public virtual Solution Solution { get; protected set; }

        public virtual string Name { get; protected set; }

        public abstract IList<string> Directories { get; }

        public void CreateSolutionDirectoryStructure()
        {
            foreach (var directory in Directories)
            {
                Directory.CreateDirectory(RootPath + directory);
            }
        }

        public void Save()
        {
            Solution.SaveAs(RootPath + "\\" + Name);
        }

        public void DeleteSuoFile()
        {
            var suoFile = RootPath + ".suo";

            if (!File.Exists(suoFile)) return;
            
            File.Delete(suoFile);
        }
    }
}