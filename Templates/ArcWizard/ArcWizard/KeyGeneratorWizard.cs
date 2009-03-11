using ArcWizard.Core;
using ArcWizard.Tasks;

namespace ArcWizard
{
    public class KeyGeneratorWizard : ProcessExecutingWizard
    {
        public override void OnEnd()
        {
            var keyPath = Configuration.RootPath + "\\Configuration\\" + Configuration.SolutionName + ".snk";
            new GenerateKeyTask(Configuration).GenerateTo(keyPath);
        }
    }
}