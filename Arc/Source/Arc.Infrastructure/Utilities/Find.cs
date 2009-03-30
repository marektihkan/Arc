using System;

namespace Arc.Infrastructure.Utilities
{
    /// <summary>
    /// Find types.
    /// </summary>
    public static class Find
    {
        /// <summary>
        /// Gets type of the specified type name.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static Type Type(string typeName)
        {
            var type = System.Type.GetType(typeName);

            if (type == null)
                throw new ArgumentException("Named type (" + typeName + ") is not found.", "typeName");
            
            return type;
        }

        /// <summary>
        /// Gets type of the specified type name which implements specified interface.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static Type TypeWithInterface<TInterface>(string typeName)
        {
            var type = Type(typeName);

            var typeInterface = typeof(TInterface).FullName;

            if (type.GetInterface(typeInterface) == null)
                throw new ArgumentException("Named type ( " + typeName + ") is not implementing " + typeInterface + " interface.", "typeName");

            return type;
        }
    }
}