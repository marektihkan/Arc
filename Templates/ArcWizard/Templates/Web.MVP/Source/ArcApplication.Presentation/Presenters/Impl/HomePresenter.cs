using $safeprojectname$.Views;

namespace $safeprojectname$.Presenters.Impl
{
    public class HomePresenter : IHomePresenter
    {
        private readonly IHomeView _view;


        public HomePresenter(IHomeView view)
        {
            _view = view;
        }

        
    }
}