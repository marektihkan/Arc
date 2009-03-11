using $solutionname$.Presentation.Presenters;
using $solutionname$.Presentation.Presenters.Impl;
using $solutionname$.Presentation.Presenters.Templates;
using $solutionname$.Presentation.Presenters.Templates.Impl;
using Ninject.Core;

namespace $safeprojectname$.Dependencies
{
    public class PresentersConfiguration : StandardModule
    {
        public override void Load()
        {
            Bind<ISiteTemplatePresenter>().To<SiteTemplatePresenter>();
            Bind<IHomePresenter>().To<HomePresenter>();
        }
    }
}