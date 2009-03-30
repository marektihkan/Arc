namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// DSL for adding parameters to service locator resolving method.
    /// </summary>
    public static class With
    {
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public static IParameters Parameters 
        {
            get { return new Parameters(); }
        }
    }
}