using Arc.Infrastructure.Configuration.Routing;

namespace $safeprojectname$.Routing
{
    public class Routes : Arc.Infrastructure.Presentation.Mvc.RoutesConfiguration
    {
        protected override void Configure()
        {
            Ignore(
                Route.Named("Resources").Url("{resource}.axd/{*pathInfo}")    
            );

            Map(
                Route.Named("Default")
                    .Url("{controller}/{action}/{id}")
                    .DefaultsAre(new { controller = "Home", action = "Index", id = "" })
            );
        }
    }
}