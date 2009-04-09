using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Validation;

namespace Arc.Infrastructure.Configuration.Dependencies
{
    /// <summary>
    /// Configuration for validation when its not used.
    /// </summary>
    public class ValidationIsNotUsedConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        /// <summary>
        /// Configures the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IValidationService>().IsImplementedBy<NullValidationService>()
            );
        }
    }
}