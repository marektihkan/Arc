using System;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Extensions
{
    public static class ComponentRegistrationExtensions
    {
        public static IKernel Kernel { private get; set; }

        public static ComponentRegistration<T> FactoryMethod<T, S>(this ComponentRegistration<T> reg, Func<S> factory) where S : T
        {
            var factoryName = typeof(GenericFactory<>).FullName + "[" + reg.ServiceType.FullName + "]";
            Kernel.Register(Component.For<GenericFactory<S>>().Named(factoryName).Instance(new GenericFactory<S>(factory)));
            reg.Configuration(Attrib.ForName("factoryId").Eq(factoryName), Attrib.ForName("factoryCreate").Eq("Create"));
            return reg;
        }

        public static ComponentRegistration<T> FactoryMethod<T, S>(this ComponentRegistration<T> reg, Func<IKernel, S> factory) where S : T
        {
            var factoryName = typeof(GenericFactoryWithKernel<>).FullName + "[" + reg.ServiceType.FullName + "]";
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