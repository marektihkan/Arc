using System.Collections;
using System.Collections.Generic;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Parameters for service locator.
    /// </summary>
    public class Parameters : IParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        public Parameters()
        {
            Arguments = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the arguments as IDictionary<string, object>.
        /// </summary>
        /// <value>The arguments.</value>
        public IDictionary<string, object> Arguments { get; private set; }

        /// <summary>
        /// Gets the arguments as IDictionary.
        /// </summary>
        /// <returns></returns>
        public IDictionary GetArguments()
        {
            var arguments = new Hashtable();
            foreach (var argument in Arguments)
            {
                arguments.Add(argument.Key, argument.Value);
            }
            return arguments;
        }

        /// <summary>
        /// Adds constructor argument.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>Parameters collecteion.</returns>
        public IParameters ConstructorArgument(string name, object value)
        {
            Arguments.Add(name, value);
            return this;
        }
    }
}