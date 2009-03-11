using ArcWizard.Core;

namespace ArcWizard
{
    public class SolutionWizard : BaseWizard
    {
        public override void OnEnd()
        {
            Solution.DeleteSuoFile();
            Solution.Save();
        }
    }
}