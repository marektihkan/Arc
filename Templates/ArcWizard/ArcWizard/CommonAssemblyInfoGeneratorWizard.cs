using ArcWizard.Core;
using ArcWizard.Tasks;

namespace ArcWizard
{
    public class CommonAssemblyInfoGeneratorWizard : ProcessExecutingWizard
    {
        public override void OnEnd()
        {
            new GenerateCommonAssemblyInfoTask(Configuration).Generate();
        }
    }
}