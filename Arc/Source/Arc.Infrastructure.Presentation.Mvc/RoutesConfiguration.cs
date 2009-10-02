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
        protected override IRouteHandler GetRouteHandler()
        {
            return new MvcRouteHandler();
        }
    }
}