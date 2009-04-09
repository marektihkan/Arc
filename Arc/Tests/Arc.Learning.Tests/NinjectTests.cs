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

            kernel.Load(new InlineModule(x => x.Bind<IService>().To<ServiceImpl>()));

            Assert.That(kernel.Get<IService>(), Is.Not.Null);
        }

        [Test]
        [Ignore]
        public void Should_not_throw_exception_when_loading_multiple_inline_modules()
        {
            IKernel kernel = new StandardKernel();
            
            kernel.Load(new InlineModule(x => x.Bind<IService>().To<ServiceImpl>()));
            kernel.Load(new InlineModule(x => x.Bind<IService2>().To<Service2Impl>()));
        }

        [Test]
        public void Should_register_generics()
        {
            IKernel kernel = new StandardKernel();

            kernel.Load(new InlineModule(x => x.Bind(typeof(IGenericService<>)).To(typeof(GenericServiceImpl<>))));

            Assert.That(kernel.Get<IGenericService<DomainEntity>>(), Is.Not.Null);
        }
    }

    public interface IGenericService<T> {}

    public class GenericServiceImpl<T> : IGenericService<T> { }

    public interface IService {}

    public class ServiceImpl : IService {}

    public interface IService2 {}

    public class Service2Impl : IService2 {}
}