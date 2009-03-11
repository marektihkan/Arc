using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace ArcWizard.Core
{
    public class EmptyWizard : IWizard
    {
        public virtual void RunStarted(object application, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
        }

        public virtual void ProjectFinishedGenerating(Project project)
        {
        }

        public virtual void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public virtual bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public virtual void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public virtual void RunFinished()
        {
        }
    }
}