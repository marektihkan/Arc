using System.Collections;
using System.Collections.Generic;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Parameters for service locator.
    /// </summary>
    public interface IParameters
    {
        /// <summary>
        /// Adds constructor argument.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>Parameters collecteion.</returns>
        IParameters ConstructorArgument(string name, object value);

        /// <summary>
        /// Gets the arguments as <c>IDictionary<string, object></c>.
        /// </summary>
        /// <value>The arguments.</value>
        IDictionary<string, object> Arguments { get; }

        /// <summary>
        /// Gets the arguments as IDictionary.
        /// </summary>
        /// <returns></returns>
        IDictionary GetArguments();
    }
}