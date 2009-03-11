using Arc.Infrastructure.Presentation.Mvp;
using $solutionname$.Presentation.Presenters.Templates;
using $solutionname$.Presentation.Views.Templates;

namespace $safeprojectname$
{
    public partial class Site : MasterPage<ISiteTemplatePresenter>, ITemplateView
    {
        protected override void HookupEventHandlers()
        {
        }
    }
}