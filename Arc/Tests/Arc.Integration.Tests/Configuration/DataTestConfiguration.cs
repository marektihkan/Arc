using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Registry;

namespace Arc.Integration.Tests.Configuration
{
    public class DataTestConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public static string FullName
        {
            get
            {
                var type = typeof(DataTestConfiguration);
                return type.FullName + ", " + type.Assembly.FullName;
            }
        }

        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IRegistry>().IsImplementedBy<LocalRegistry>()
            );
        }
    }
}