using Arc.Testing.Utilities;
using Arc.Unit.Tests.Fakes.Entities;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Testing.Utilities
{
    [TestFixture]
    public class AutoMockerTests
    {

        private IAutoMocker CreateSUT()
        {
            return new AutoMocker();
        }

        [Test]
        public void Should_create_mock_for_specified_type()
        {
            var actual = CreateSUT().Get<IService>();

            actual.DoSomething();

            actual.AssertWasCalled(x => x.DoSomething());
        }

        [Test]
        public void Should_get_same_mock_when_asking_for_same_type()
        {
            var target = CreateSUT();

            var expected = target.Get<IService>();
            var actual = target.Get<IService>();

            Assert.That(actual, Is.SameAs(expected));
        }

    }
}