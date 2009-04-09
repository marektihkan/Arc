using System;
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
                    .ImplementedBy(Registration.ImplementationType)
                    .LifeStyle.Is(LifeStyleFactory.Create(Registration.Scope))
                );        
        }
    }
}