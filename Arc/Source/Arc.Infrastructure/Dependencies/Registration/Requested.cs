using System;

namespace Arc.Infrastructure.Dependencies.Registration
{
    public static class Requested
    {
        public static IServiceBindingSyntax Service<T>( )
        {
            return new RegistrationImpl(typeof(T));
        }

        public static IServiceBindingSyntax Service(Type type)
        {
            return new RegistrationImpl(type);
        }
    }
}