using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Ninject.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class NinjectTests
    {
        [Test]
        public void Should_register_new_type()
        {
            IKernel kernel = new StandardKernel();

            kernel.Load(new InlineModule(x => x.Bind<IService>().To<Service>()));

            Assert.That(kernel.Get<IService>(), Is.Not.Null);
        }

        [Test]
        [Ignore]
        public void Should_not_throw_exception_when_loading_multiple_inline_modules()
        {
            IKernel kernel = new StandardKernel();
            
            kernel.Load(new InlineModule(x => x.Bind<IService>().To<Service>()));
            kernel.Load(new InlineModule(x => x.Bind<IService2>().To<Service2>()));
        }

        [Test]
        [Ignore("Ninject doesn't support generic registration.")]
        public void Should_register_generics()
        {
            IKernel kernel = new StandardKernel();

            kernel.Load(new InlineModule(x => x.Bind(typeof(IRepository<>)).To(typeof(Repository<>))));

            Assert.That(kernel.Get<IRepository<DomainEntity>>(), Is.Not.Null);
        }
    }

    public interface IService
    {
    }

    public class Service : IService
    {
    }

    public interface IService2
    {
    }

    public class Service2 : IService2
    {
    }
}