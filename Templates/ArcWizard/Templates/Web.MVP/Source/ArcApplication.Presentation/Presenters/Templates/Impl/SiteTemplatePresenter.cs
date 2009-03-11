using $safeprojectname$.Views.Templates;

namespace $safeprojectname$.Presenters.Templates.Impl
{
    public class SiteTemplatePresenter : ISiteTemplatePresenter
    {
        private readonly ITemplateView _view;

        public SiteTemplatePresenter(ITemplateView view)
        {
            _view = view;
        }
    }
}