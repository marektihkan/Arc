using Arc.Infrastructure.Presentation.Mvp;
using $solutionname$.Presentation.Presenters;
using $solutionname$.Presentation.Views;

namespace $safeprojectname$
{
    public partial class Default : Page<IHomePresenter>, IHomeView
    {
        protected override void HookupEventHandlers()
        {
        }
    }
}