using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Registration
{
    internal static class RegistrationStrategyFactory
    {
        public static IRegistrationStrategy Create(IRegistration registration, ServiceLocator locator)
        {
            if (registration.Factory != null)
                return new FactoryRegistrationStrategy(registration, locator);
            return new ImplementedRegistrationStrategy(registration, locator);
        }
    }
}