using Arc.Infrastructure.Dependencies.Registration;
using StructureMap.Pipeline;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    internal class FactoryRegistrationStrategy : IRegistrationStrategy
    {
        private IRegistration Registration { get; set; }
        private ServiceLocator ServiceLocator { get; set; }

        public FactoryRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            Registration = registration;
        }

        public void Register()
        {
            ServiceLocator.Container.Configure(x =>
                x.ForRequestedType(Registration.ServiceType)
                    .CacheBy(LifeStyleFactory.Create(Registration.Scope)));

            var instance = new ConstructorInstance<object>(context => Registration.Factory.Invoke(ServiceLocator));
            ServiceLocator.Container.SetDefault(Registration.ServiceType, instance);
        }
    }
}