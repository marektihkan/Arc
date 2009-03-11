using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace ArcWizard.Core
{
    public class Configuration
    {
        public Configuration(_DTE application, WizardRunKind kind, Dictionary<string, string> replacements)
        {
            Application = application;
            Kind = kind;
            Replacements = replacements;
            
            DefineSolutionName();
            DefineSolutionRoot();
        }

        private void DefineSolutionName()
        {
            if (Kind == WizardRunKind.AsMultiProject)
            {
                SolutionName = Replacements["$safeprojectname$"];
            }

            Replacements.Add("$solutionname$", SolutionName);
        }

        private void DefineSolutionRoot()
        {
            if (Kind == WizardRunKind.AsNewProject)
            {
                Replacements.Add("$solutionrootpath$", GetSolutionRootPath() + SolutionName + "\\");
            }
        }

        private string GetSolutionName()
        {
            return Replacements["$solutionname$"];
        }

        private string GetSolutionFileName()
        {
            return GetSolutionName() + ".sln";
        }

        private string GetSolutionFileFullName()
        {
            return Application.Solution.Properties.Item("Path").Value.ToString();
        }

        private string GetSolutionRootPath()
        {
            return GetSolutionFileFullName().Replace(GetSolutionFileName(), "");
        }

        public _DTE Application { get; private set; }

        public WizardRunKind Kind { get; private set; }

        public Dictionary<string, string> Replacements { get; private set; }

        public static string SolutionName { get; private set; }

        public string RootPath
        {
            get { return GetSolutionRootPath() + GetSolutionName(); }
        }
    }
}