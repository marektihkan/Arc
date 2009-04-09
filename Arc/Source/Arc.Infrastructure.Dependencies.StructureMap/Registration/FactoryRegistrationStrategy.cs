using Arc.Infrastructure.Dependencies.Registration;
using StructureMap.Pipeline;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    internal class FactoryRegistrationStrategy : BaseRegistrationStrategy
    {
        public FactoryRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator) 
            : base(registration, serviceLocator)
        {
        }

        public override void Register()
        {
            ServiceLocator.Container.Configure(x =>
                x.ForRequestedType(Registration.ServiceType)
                    .CacheBy(LifeStyleFactory.Create(Registration.Scope)));

            var instance = new ConstructorInstance<object>(context => Registration.Factory.Invoke(ServiceLocator));
            ServiceLocator.Container.SetDefault(Registration.ServiceType, instance);
        }
    }
}