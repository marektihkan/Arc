using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Registry;
using Ninject.Core;

namespace Arc.Integration.Tests.Configuration
{
    public class DataTestConfiguration : StandardModule
    {
        public static string FullName
        {
            get
            {
                var type = typeof(DataTestConfiguration);
                return type.FullName + ", " + type.Assembly.FullName;
            }
        }

        public override void Load()
        {
            Bind<IRegistry>().To<LocalRegistry>().ForMembersOf<UnitOfWorkFactory>();
        }
    }
}