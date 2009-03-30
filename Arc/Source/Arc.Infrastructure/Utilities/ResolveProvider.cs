using System;

namespace Arc.Infrastructure.Utilities
{
    /// <summary>
    /// Provider resolver.
    /// </summary>
    /// <typeparam name="T">Type of provider interface.</typeparam>
    public static class ResolveProvider<T>
    {
        /// <summary>
        /// Creates provider of specified type name.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        public static T Named(string providerFullName)
        {
            return WithRealType(Find.TypeWithInterface<T>(providerFullName));
        }

        /// <summary>
        /// Creates provider of specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        public static T WithRealType(Type provider)
        {
            if (provider.FindInterfaces((type, x) => type == x, typeof(T)).Length == 0)
                throw new ArgumentException("Specified type is not implementing specified interface.", "provider");

            return (T)Activator.CreateInstance(provider);
        }
    }
}