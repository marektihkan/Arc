using Castle.MicroKernel.Registration;
using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Registration
{
    internal class ImplementedRegistrationStrategy : BaseRegistrationStrategy, IRegistrationStrategy
    {
        public ImplementedRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator) 
            : base(registration, serviceLocator)
        {
        }

        public override void Register()
        {
            ServiceLocator.Container.Register(
                Component.For(Registration.ServiceType)
                    .Named(Registration.ServiceType.FullName + "_" + Registration.ImplementationType.FullName)
                    .ImplementedBy(Registration.ImplementationType)
                    .LifeStyle.Is(LifeStyleFactory.Create(Registration.Scope))
                );        
        }
    }
}