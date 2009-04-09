using System;

namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// DSL for registering services to service locator.
    /// </summary>
    public static class Requested
    {
        /// <summary>
        /// Registers service interface to service locator.
        /// </summary>
        /// <typeparam name="TService">The type of the service interface.</typeparam>
        /// <returns></returns>
        public static IServiceBindingSyntax Service<TService>( )
        {
            return new RegistrationImpl(typeof(TService));
        }

        /// <summary>
        /// Registers service interface to service locator.
        /// </summary>
        /// <param name="type">The service interface type.</param>
        /// <returns></returns>
        public static IServiceBindingSyntax Service(Type type)
        {
            return new RegistrationImpl(type);
        }
    }
}