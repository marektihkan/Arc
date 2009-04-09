using Arc.Infrastructure.Dependencies.Ninject.Extensions;
using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;

namespace Arc.Infrastructure.Dependencies.Ninject.Registration
{
    internal class FactoryRegistrationStrategy : BaseRegistrationStrategy
    {
        public FactoryRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator) 
            : base(registration, serviceLocator)
        {
        }

        public override void Register()
        {
            //NOTE: Workaround for ninject inline module loeading bug.
            var kernel = ServiceLocator.Kernel;

            var binding = kernel.Components.BindingFactory.Create(Registration.ServiceType);
            binding.Behavior = LifeStyleFactory.Create(Registration.Scope);

            binding.Provider = new FactoryProvider(() => Registration.Factory.Invoke(ServiceLocator), Registration.ServiceType);

            kernel.AddBinding(binding);
        }
    }
}