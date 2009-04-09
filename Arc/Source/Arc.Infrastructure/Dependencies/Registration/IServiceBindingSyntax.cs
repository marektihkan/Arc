using System;

namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Configuration syntax for binding service to implementation.
    /// </summary>
    public interface IServiceBindingSyntax
    {
        /// <summary>
        /// Service is implemented by specified type.
        /// </summary>
        /// <typeparam name="TImplementation">Type of implementation.</typeparam>
        /// <returns></returns>
        IRegistration IsImplementedBy<TImplementation>();

        /// <summary>
        /// Service is implemented by specified type.
        /// </summary>
        /// <param name="type">The type of implementation.</param>
        /// <returns></returns>
        IRegistration IsImplementedBy(Type type);

        /// <summary>
        /// Service is constructed by specified factory method.
        /// </summary>
        /// <param name="factoryMethod">The factory method.</param>
        /// <returns></returns>
        IRegistration IsConstructedBy(Func<IServiceLocator, object> factoryMethod);
    }
}