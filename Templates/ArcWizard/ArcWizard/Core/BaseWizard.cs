using EnvDTE;

namespace ArcWizard.Core
{
    public class BaseWizard : EmptyWizard
    {
        public Configuration Configuration { get; protected set; }

        public ArcSolution Solution { get; protected set; }


        public override void RunStarted(object application, System.Collections.Generic.Dictionary<string, string> replacementsDictionary, Microsoft.VisualStudio.TemplateWizard.WizardRunKind runKind, object[] customParams)
        {
            base.RunStarted(application, replacementsDictionary, runKind, customParams);

            Configuration = new Configuration(application as _DTE, runKind, replacementsDictionary);
            Solution = new ArcSolution(Configuration);

            OnStart();
        }

        public override void ProjectFinishedGenerating(Project project)
        {
            base.ProjectFinishedGenerating(project);

            OnProjectGenerated(project);
        }

        public override void RunFinished()
        {
            base.RunFinished();

            OnEnd();
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnEnd()
        {
        }

        public virtual void OnProjectGenerated(Project project)
        {
        }
    }
}