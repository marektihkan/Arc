using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies.Ninject.Registration
{
    internal abstract class BaseRegistrationStrategy : IRegistrationStrategy
    {
        public BaseRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            Registration = registration;
        }

        protected ServiceLocator ServiceLocator { get; set; }
        protected IRegistration Registration { get; set; }
        
        public abstract void Register();
    }
}