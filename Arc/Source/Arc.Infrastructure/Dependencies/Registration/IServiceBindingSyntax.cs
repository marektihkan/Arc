using System;
using System.Linq.Expressions;

namespace Arc.Infrastructure.Dependencies.Registration
{
    public interface IServiceBindingSyntax
    {
        IRegistration IsImplementedBy<T>();
        IRegistration IsImplementedBy(Type type);

        IRegistration IsConstructedBy(Func<IServiceLocator, object> expression);
    }
}