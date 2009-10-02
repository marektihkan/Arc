using System.Web.Routing;

namespace Arc.Infrastructure.Configuration.Routing
{
    public interface IRoutesConfiguration
    {
        void Load(RouteCollection routes);
    }
}