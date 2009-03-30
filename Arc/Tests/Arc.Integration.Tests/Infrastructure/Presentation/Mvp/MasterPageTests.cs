using Arc.Infrastructure.Configuration;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Presentation.Mvp;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Integration.Tests.Infrastructure.Presentation.Mvp
{
    [TestFixture]
    public class MasterPageTests
    {
        private MasterPageTester CreateSUT()
        {
            return new MasterPageTester();
        }


        [Test]
        public void Should_inject_presenter_to_view_and_hookup_events()
        {
            var serviceLocator = new Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator();

            Configure.ServiceLocator.ProviderTo(serviceLocator)
                .With(new DependencyConfiguration());
            
            var target = CreateSUT();

            target.Initialize();

            Assert.That(target.Presenter, Is.Not.Null);
            Assert.That(target.Presenter.View, Is.SameAs(target));
            Assert.That(target.HookupEventsWasCalled, Is.True);
        }
    }
}