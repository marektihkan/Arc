using Arc.Infrastructure.Dependencies.CastleWindsor.Extensions;
using Castle.MicroKernel.Registration;
using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Registration
{
    internal class FactoryRegistrationStrategy : BaseRegistrationStrategy
    {
        public FactoryRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator) 
            : base(registration, serviceLocator)
        {
        }

        public override void Register()
        {
            ServiceLocator.Container.Register(
                Component.For(Registration.ServiceType)
                    .FactoryMethod(() => Registration.Factory.Invoke(ServiceLocator))
                    .LifeStyle.Is(LifeStyleFactory.Create(Registration.Scope)));
        }
    }
}