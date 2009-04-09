using System;
using System.Linq.Expressions;

namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Registration for service locator.
    /// </summary>
    public interface IRegistration
    {
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>The type of the service.</value>
        Type ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the life style scope.
        /// </summary>
        /// <value>The life style scope.</value>
        ServiceLifeStyle Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of the implementation.
        /// </summary>
        /// <value>The type of the implementation.</value>
        Type ImplementationType { get; set; }

        /// <summary>
        /// Gets or sets the factory method.
        /// </summary>
        /// <value>The factory method.</value>
        Func<IServiceLocator, object> Factory { get; set; }

        /// <summary>
        /// Gets the life style builder.
        /// </summary>
        /// <value>The life style builder.</value>
        IServiceLifeStyleSyntax LifeStyle { get; }
    }
}