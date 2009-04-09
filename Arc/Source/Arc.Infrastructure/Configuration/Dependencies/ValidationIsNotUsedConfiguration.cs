using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Validation;

namespace Arc.Infrastructure.Configuration.Dependencies
{
    public class ValidationIsNotUsedConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IValidationService>().IsImplementedBy<NullValidationService>()
            );
        }
    }
}