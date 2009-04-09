using System;
using System.Linq.Expressions;

namespace Arc.Infrastructure.Dependencies.Registration
{
    public interface IRegistration
    {
        Type ServiceType { get; set; }
        ServiceLifeStyle Scope { get; set; }
        Type ImplementationType { get; set; }
        Func<IServiceLocator, object> Factory { get; set; }
        IServiceLifeStyleSyntax LifeStyle { get; }
    }
}