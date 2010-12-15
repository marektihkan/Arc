using System;
using System.Web.Mvc;
using System.Web.Routing;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Presentation.Mvc
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)ServiceLocator.Resolve(controllerType);
        }
        
        public override void ReleaseController(IController controller)
        {
            ServiceLocator.Release(controller);
        }
    }
}