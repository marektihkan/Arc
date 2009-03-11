using Arc.Unit.Tests.Fakes.Entities;
using Arc.Unit.Tests.Fakes.TestingStyles;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Testing.Styles
{
    [TestFixture]
    public class StyleTests
    {

        [Test]
        public void All_styles_should_invoke_cleanup_in_tear_down()
        {
            var target = new BaseStyleTester();

            target.MainTearDown();

            Assert.That(target.InvokedActions[0], Is.EqualTo("CleanUp"));
        }

        [Test]
        public void All_styles_should_be_able_to_store_SUT()
        {
            var target = new BaseStyleTester();
            var expected = new Person();

            target.SUT = expected;

            Assert.That(target.SUT, Is.SameAs(expected));
        }

        [Test]
        public void All_styles_should_be_able_to_store_dependencies_by_type()
        {
            var target = new BaseStyleTester();
            var expected = new Person();

            target.MainSetup();
            target.Dependencies.Register(expected);

            Assert.That(target.Dependencies.Get<Person>(), Is.SameAs(expected));
        }

        [Test]
        public void All_styles_should_be_able_to_get_mocks_by_type()
        {
            var target = new BaseStyleTester();
            
            target.MainSetup();
            var expected = target.Mockery.Get<IService>();

            Assert.That(target.Mockery.Get<IService>(), Is.SameAs(expected));
        }

        [Test]
        public void Arrange_act_assert_style_should_invoke_arrange_and_act_in_setup()
        {
            var target = new ArrangeActAssertTester();

            target.MainSetup();

            Assert.That(target.InvokedActions[0], Is.EqualTo("Arrange"));
            Assert.That(target.InvokedActions[1], Is.EqualTo("Act"));
        }

        [Test]
        public void Context_specification_style_should_invoke_context_and_because_in_setup()
        {
            var target = new ContextSpecificationTester();

            target.MainSetup();

            Assert.That(target.InvokedActions[0], Is.EqualTo("Context"));
            Assert.That(target.InvokedActions[1], Is.EqualTo("Because"));
        }

        [Test]
        public void Given_when_then_style_should_invoke_given_and_when_in_setup()
        {
            var target = new GivenWhenThenTester();

            target.MainSetup();

            Assert.That(target.InvokedActions[0], Is.EqualTo("Given"));
            Assert.That(target.InvokedActions[1], Is.EqualTo("When"));
        }

    }
}