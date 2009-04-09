using Arc.Infrastructure.Dependencies.Ninject.Extensions;
using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;

namespace Arc.Infrastructure.Dependencies.Ninject.Registration
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
            //NOTE: Workaround for ninject inline module loeading bug.
            var kernel = ServiceLocator.Kernel;

            var binding = kernel.Components.BindingFactory.Create(Registration.ServiceType);
            binding.Behavior = LifeStyleFactory.Create(Registration.Scope);

            binding.Provider = new FactoryProvider(() => Registration.Factory.Invoke(ServiceLocator), Registration.ServiceType);

            kernel.AddBinding(binding);
        }
    }
}