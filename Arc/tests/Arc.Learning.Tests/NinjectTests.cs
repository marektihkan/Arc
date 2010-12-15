using Arc.Learning.Tests.Fakes.Model;
using Ninject;
using NUnit.Framework;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class NinjectTests
    {
        [Test]
        public void Should_register_new_type()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IService>().To<ServiceImpl>();

            Assert.That(kernel.Get<IService>(), Is.Not.Null);
        }

        [Test]
        public void Should_not_throw_exception_when_loading_multiple_inline_modules()
        {
            IKernel kernel = new StandardKernel();
            
            kernel.Bind<IService>().To<ServiceImpl>();
            kernel.Bind<IService2>().To<Service2Impl>();
        }

        [Test]
        public void Should_register_generics()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind(typeof(IGenericService<>)).To(typeof(GenericServiceImpl<>));

            Assert.That(kernel.Get<IGenericService<DomainEntity>>(), Is.Not.Null);
        }
    }
}