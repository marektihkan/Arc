using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Registry;

namespace Arc.Integration.Tests.Configuration
{
    public class DataTestConfiguration : IConfiguration<IServiceLocator>
    {
        public static string FullName
        {
            get
            {
                var type = typeof(DataTestConfiguration);
                return type.FullName + ", " + type.Assembly.FullName;
            }
        }

        public void Load(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IRegistry>().IsImplementedBy<LocalRegistry>()
            );
        }
    }
}