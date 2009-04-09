using System;

namespace Arc.Infrastructure.Dependencies.Registration
{
    public class RegistrationImpl : IRegistration, IServiceBindingSyntax, IServiceLifeStyleSyntax
    {
        public RegistrationImpl(Type serviceType)
        {
            ServiceType = serviceType;
        }

        public Type ServiceType { get; set; }
        public Type ImplementationType { get; set; }
        public ServiceLifeStyle Scope { get; set; }
        public Func<IServiceLocator, object> Factory { get; set; }
        public IServiceLifeStyleSyntax LifeStyle
        {
            get { return this; }
        }

        public IRegistration IsImplementedBy<T>()
        {
            return IsImplementedBy(typeof(T));
        }

        public IRegistration IsImplementedBy(Type type)
        {
            ImplementationType = type;
            return this;
        }

        public IRegistration IsConstructedBy(Func<IServiceLocator, object> expression)
        {
            Factory = expression;
            return this;
        }

        public IRegistration IsTransient()
        {
            Scope = ServiceLifeStyle.Transient;
            return this;
        }

        public IRegistration IsOnePerRequest()
        {
            Scope = ServiceLifeStyle.OnePerRequest;
            return this;
        }

        public IRegistration IsOnePerThread()
        {
            Scope = ServiceLifeStyle.OnePerThread;
            return this;
        }

        public IRegistration IsSingelton()
        {
            Scope = ServiceLifeStyle.Singleton;
            return this;
        }

        public IRegistration Is(ServiceLifeStyle lifeStyle)
        {
            Scope = lifeStyle;
            return this;
        }
    }
}