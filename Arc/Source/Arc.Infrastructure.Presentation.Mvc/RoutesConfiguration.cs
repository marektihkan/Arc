using System.Web.Mvc;
using System.Web.Routing;
using Arc.Infrastructure.Configuration.Routing;

namespace Arc.Infrastructure.Presentation.Mvc
{
    /// <summary>
    /// Configuration for MVC application routes.
    /// </summary>
    public abstract class RoutesConfiguration : BaseRoutesConfiguration
    {
        /// <summary>
        /// Ignores the route.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="routes">The routes.</param>
        protected override void IgnoreRoute(IRouteBuilder route, RouteCollection routes)
        {
            var data = route.Data;
            routes.IgnoreRoute(data.Url, data.Constraint);
        }

        /// <summary>
        /// Registers the route.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="routes">The routes.</param>
        protected override void RegisterRoute(IRouteBuilder route, RouteCollection routes)
        {
            var data = route.Data;
            routes.MapRoute(data.Name, data.Url, data.Defaults, data.Constraint, data.Namespaces);
        }
    }
}