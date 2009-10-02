using System;
using System.Web.Mvc;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Presentation.Mvc
{
    public class ControllerFactory : DefaultControllerFactory
    { 
        protected override IController GetControllerInstance(Type controllerType)
        {
            return (IController) ServiceLocator.Resolve(controllerType);
        }
    }
}