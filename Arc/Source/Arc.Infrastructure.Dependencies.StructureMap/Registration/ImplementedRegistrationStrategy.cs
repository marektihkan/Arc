using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    internal class ImplementedRegistrationStrategy : BaseRegistrationStrategy
    {
        public ImplementedRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator) 
            : base(registration, serviceLocator)
        {
        }

        public override void Register()
        {
            ServiceLocator.Container.Configure(x =>
                x.ForRequestedType(Registration.ServiceType)
                    .AddConcreteType(Registration.ImplementationType)
                    .CacheBy(LifeStyleFactory.Create(Registration.Scope))
                );
        }
    }
}