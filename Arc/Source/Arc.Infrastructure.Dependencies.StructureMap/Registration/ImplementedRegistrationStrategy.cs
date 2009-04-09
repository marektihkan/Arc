using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    internal class ImplementedRegistrationStrategy : IRegistrationStrategy
    {
        private IRegistration Registration { get; set; }
        private ServiceLocator ServiceLocator { get; set; }

        public ImplementedRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            Registration = registration;
        }

        public void Register()
        {
            ServiceLocator.Container.Configure(x =>
                x.ForRequestedType(Registration.ServiceType)
                    .AddConcreteType(Registration.ImplementationType)
                    .CacheBy(LifeStyleFactory.Create(Registration.Scope))
                );
        }
    }
}