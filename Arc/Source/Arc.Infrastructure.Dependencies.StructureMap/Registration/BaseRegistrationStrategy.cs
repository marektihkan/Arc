using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    internal abstract class BaseRegistrationStrategy : IRegistrationStrategy
    {
        protected BaseRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            Registration = registration;
        }

        protected IRegistration Registration { get; set; }
        protected ServiceLocator ServiceLocator { get; set; }
        public abstract void Register();
    }
}