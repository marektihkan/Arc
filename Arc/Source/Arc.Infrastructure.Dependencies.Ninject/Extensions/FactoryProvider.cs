using System;
using Ninject.Core.Activation;
using Ninject.Core.Creation;

namespace Arc.Infrastructure.Dependencies.Ninject.Extensions
{
    internal class FactoryProvider : IProvider
    {
        public FactoryProvider(Func<object> callback, Type serviceType)
        {
            Callback = callback;
            ServiceType = serviceType;
        }

        private Func<object> Callback { get; set; }

        private Type ServiceType { get; set; }

        public bool IsCompatibleWith(IContext context)
        {
            return true;
        }

        public Type GetImplementationType(IContext context)
        {
            return ServiceType;
        }

        public object Create(IContext context)
        {
            return Callback.Invoke();
        }

        public Type Prototype
        {
            get { return ServiceType; }
        }
    }
}