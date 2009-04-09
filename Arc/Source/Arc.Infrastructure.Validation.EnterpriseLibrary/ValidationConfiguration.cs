using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Validation.EnterpriseLibrary
{
    public class ValidationConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IValidationService>().IsImplementedBy<ValidationService>()
            );
        }
    }
}