using $solutionname$.Presentation.Presenters;
using $solutionname$.Presentation.Presenters.Impl;
using $solutionname$.Presentation.Views;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace $safeprojectname$.Presentation
{
    [TestFixture]
    public class HomePresenterTests
    {
        private IHomeView _view;

        [SetUp]
        public void SetUp()
        {
            _view = MockRepository.GenerateMock<IHomeView>();
        }

        private IHomePresenter CreateSUT()
        {
            return new HomePresenter(_view);
        }

    }
}