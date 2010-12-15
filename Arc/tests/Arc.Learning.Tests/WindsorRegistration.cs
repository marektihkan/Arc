using System;
using System.Reflection;
using Arc.Learning.Tests.Fakes.Model;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class WindsorRegistration
    {
        [Test]
        public void Should_register_to_factory_method()
        {
            var container = new WindsorContainer();

            ComponentRegistrationExtensions.Kernel = container.Kernel;
            container.AddFacility("factory.support", new FactorySupportFacility());

            container.Register(
                Component.For<IObjectFactory>()
                    .ImplementedBy<ObjectFactoryImpl>()
                    .LifeStyle.Singleton,
                Component.For<ICreatedObject>()
                    .FactoryMethod(context => context.Resolve<IObjectFactory>().Create())
                    .LifeStyle.Transient
                );


            var firstCreatedObject = container.Resolve<ICreatedObject>();
            var secondCreatedObject = container.Resolve<ICreatedObject>();

            Assert.That(firstCreatedObject, Is.Not.SameAs(secondCreatedObject));

        }

        [Test]
        public void Auto_regitration_example()
        {
            var container = new WindsorContainer();

            container.Register(
                AllTypes.Pick().FromAssembly(Assembly.GetExecutingAssembly())
                .If(t => t.FullName == "").WithService.FirstInterface());
        }

        [Test]
        public void Should_register_service_for_conrete_type()
        {
            var container = new WindsorContainer();

            container.Register(
                Component.For<ICreatedObject>().ImplementedBy<CreatedObjectImpl>());
        }
    }


    public static class ComponentRegistrationExtensions
    {
        public static IKernel Kernel { private get; set; }

        public static ComponentRegistration<T> FactoryMethod<T, S>(this ComponentRegistration<T> reg, Func<S> factory) where S : T
        {
            var factoryName = typeof(GenericFactory<S>).FullName;
            Kernel.Register(Component.For<GenericFactory<S>>().Named(factoryName).Instance(new GenericFactory<S>(factory)));
            reg.Configuration(Attrib.ForName("factoryId").Eq(factoryName), Attrib.ForName("factoryCreate").Eq("Create"));
            return reg;
        }

        public static ComponentRegistration<T> FactoryMethod<T, S>(this ComponentRegistration<T> reg, Func<IKernel, S> factory) where S : T
        {
            var factoryName = typeof(GenericFactoryWithKernel<S>).FullName;
            Kernel.Register(Component.For<GenericFactoryWithKernel<S>>().Named(factoryName).Instance(new GenericFactoryWithKernel<S>(factory, Kernel)));
            reg.Configuration(Attrib.ForName("factoryId").Eq(factoryName), Attrib.ForName("factoryCreate").Eq("Create"));
            return reg;
        }

        private class GenericFactoryWithKernel<T>
        {
            private readonly Func<IKernel, T> factoryMethod;
            private readonly IKernel kernel;

            public GenericFactoryWithKernel(Func<IKernel, T> factoryMethod, IKernel kernel)
            {
                this.factoryMethod = factoryMethod;
                this.kernel = kernel;
            }

            public T Create()
            {
                return factoryMethod(kernel);
            }
        }

        private class GenericFactory<T>
        {
            private readonly Func<T> factoryMethod;

            public GenericFactory(Func<T> factoryMethod)
            {
                this.factoryMethod = factoryMethod;
            }

            public T Create()
            {
                return factoryMethod();
            }

        }
    }
}