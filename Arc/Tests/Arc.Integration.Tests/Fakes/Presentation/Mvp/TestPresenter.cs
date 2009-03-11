namespace Arc.Integration.Tests.Fakes.Presentation.Mvp
{
    class TestPresenter : ITestPresenter
    {
        public TestPresenter(ITestView view)
        {
            View = view;
        }

        public ITestView View { get; set; }
    }
}