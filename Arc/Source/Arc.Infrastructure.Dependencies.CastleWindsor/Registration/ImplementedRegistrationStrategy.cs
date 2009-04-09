using Castle.MicroKernel.Registration;
using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Registration
{
    internal class ImplementedRegistrationStrategy : IRegistrationStrategy
    {
        private ServiceLocator ServiceLocator { get; set; }
        private IRegistration Registration { get; set; }

        public ImplementedRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            Registration = registration;
        }



        public void Register()
        {
            ServiceLocator.Container.Register(
                Component.For(Registration.ServiceType)
                    .ImplementedBy(Registration.ImplementationType)
                    .LifeStyle.Is(LifeStyleFactory.Create(Registration.Scope))
                );        
        }
    }
}