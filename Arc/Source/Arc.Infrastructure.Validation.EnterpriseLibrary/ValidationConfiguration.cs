using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Validation.EnterpriseLibrary
{
    /// <summary>
    /// Configuration for validation with Enterprise Library Validation Application Block.
    /// </summary>
    public class ValidationConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        /// <summary>
        /// Configures the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IValidationService>().IsImplementedBy<ValidationService>()
            );
        }
    }
}