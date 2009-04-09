using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    internal static class RegistrationStrategyFactory
    {
        public static IRegistrationStrategy Create(IRegistration registration, ServiceLocator serviceLocator)
        {
            if (registration.Factory != null)
                return new FactoryRegistrationStrategy(registration, serviceLocator);
            return new ImplementedRegistrationStrategy(registration, serviceLocator);
        }
    }
}