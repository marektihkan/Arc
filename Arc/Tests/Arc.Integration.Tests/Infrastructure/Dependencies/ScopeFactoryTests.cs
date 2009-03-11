using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Ninject;
using Ninject.Core.Behavior;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Integration.Tests.Infrastructure.Dependencies
{
    [TestFixture]
    public class ScopeFactoryTests
    {

        private IScopeFactory CreateSUT()
        {
            return new ScopeFactory();
        }


        [Test]
        public void Factory_should_have_transient_scope()
        {
            var target = CreateSUT();

            var actual = target.Transient;

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Implementation, Is.InstanceOfType(typeof (TransientBehavior)));
        }

        [Test]
        public void Factory_should_have_singleton_scope()
        {
            var target = CreateSUT();

            var actual = target.Singleton;

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Implementation, Is.InstanceOfType(typeof(SingletonBehavior)));
        }

        [Test]
        public void Factory_should_have_one_per_request_scope()
        {
            var target = CreateSUT();

            var actual = target.OnePerRequest;

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Implementation, Is.InstanceOfType(typeof(OnePerRequestBehavior)));
        }

        [Test]
        public void Factory_should_have_one_per_thread_scope()
        {
            var target = CreateSUT();

            var actual = target.OnePerThread;

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Implementation, Is.InstanceOfType(typeof(OnePerThreadBehavior)));
        }
    }
}