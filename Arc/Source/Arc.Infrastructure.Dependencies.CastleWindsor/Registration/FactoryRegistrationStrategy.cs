using Arc.Infrastructure.Dependencies.CastleWindsor.Extensions;
using Castle.MicroKernel.Registration;
using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Registration
{
    public class FactoryRegistrationStrategy : IRegistrationStrategy
    {
        private ServiceLocator ServiceLocator { get; set; }
        private IRegistration Registration { get; set; }

        public FactoryRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            Registration = registration;
        }

        public void Register()
        {
            ServiceLocator.Container.Register(
                Component.For(Registration.ServiceType)
                    .FactoryMethod(() => Registration.Factory.Invoke(ServiceLocator))
                    .LifeStyle.Is(LifeStyleFactory.Create(Registration.Scope)));
        }
    }
}