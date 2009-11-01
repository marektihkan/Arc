using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;

namespace $safeprojectname$
{
    public abstract class ArcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Configure();
            ConfigureRoutes();
            ConfigureViewEngine();
            ConfigureControllerFactory();
        }

        protected abstract void ConfigureViewEngine();

        public static void ConfigureRoutes()
        {
            var configuration = ServiceLocator.Resolve<IConfiguration<RouteCollection>>();
            if (configuration == null) return;

            configuration.Load(RouteTable.Routes);
        }

        public static void ConfigureControllerFactory()
        {
            var factory = ServiceLocator.Resolve<IControllerFactory>();
            if (factory == null) return;

            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}