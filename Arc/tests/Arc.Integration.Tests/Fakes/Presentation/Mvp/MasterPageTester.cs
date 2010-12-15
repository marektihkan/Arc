using System;
using Arc.Infrastructure.Presentation.Mvp;

namespace Arc.Integration.Tests.Fakes.Presentation.Mvp
{
    public class MasterPageTester : MasterPage<ITestPresenter>, ITestView
    {
        public new ITestPresenter Presenter
        {
            get { return base.Presenter; }
        }

        public bool HookupEventsWasCalled { get; set; }

        public void Initialize()
        {
            base.OnInit(EventArgs.Empty);
        }

        protected override void HookupEventHandlers()
        {
            HookupEventsWasCalled = true;
        }
    }
}