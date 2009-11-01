using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Presentation.Mvc;
using FluentNHibernate.Cfg;
using $safeprojectname$.Dependencies;
using $safeprojectname$.Routing;

namespace $safeprojectname$
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            Application
                .ServiceLocatorIs<Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator>()
                .Load(
                    RegistryConfiguration.Default(),
                    DataConfiguration.Default(GetDatabaseConfiguration()),
                    LoggingIsNotUsedConfiguration.Default(),
                    ValidationIsNotUsedConfiguration.Default(),
                    PresentationConfiguration.WithRouting<Routes>()
                )
                .Apply(
                    ControllersConvention.ApplyTo("$solutionname$.Presentation")
                );
        }

        private static FluentConfiguration GetDatabaseConfiguration()
        {
            return null;
        }
    }
}