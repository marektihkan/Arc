using $solutionname$.Presentation.Presenters.Templates;
using $solutionname$.Presentation.Presenters.Templates.Impl;
using $solutionname$.Presentation.Views.Templates;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace $safeprojectname$.Presentation.Templates
{
    [TestFixture]
    public class SiteTemplatePresenterTests
    {
        private ITemplateView _view;

        [SetUp]
        public void SetUp()
        {
            _view = MockRepository.GenerateMock<ITemplateView>();
        }

        private ISiteTemplatePresenter CreateSUT()
        {
            return new SiteTemplatePresenter(_view);
        }


    }
}