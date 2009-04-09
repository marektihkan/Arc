using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;

namespace Arc.Infrastructure.Dependencies.Ninject.Registration
{
    internal class ImplementedRegistrationStrategy : BaseRegistrationStrategy
    {
        public ImplementedRegistrationStrategy(IRegistration registration, ServiceLocator serviceLocator) 
            : base(registration, serviceLocator)
        {
        }

        public override void Register()
        {
            //NOTE: Workaround for ninject inline module loeading bug.
            var kernel = ServiceLocator.Kernel;

            var binding = kernel.Components.BindingFactory.Create(Registration.ServiceType);
            binding.Behavior = LifeStyleFactory.Create(Registration.Scope);
            binding.Provider = kernel.Components.ProviderFactory.Create(Registration.ImplementationType);

            kernel.AddBinding(binding);
        }
    }
}