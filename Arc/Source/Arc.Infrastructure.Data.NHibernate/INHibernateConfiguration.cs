using NHibernate;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Configuration for NHibernate.
    /// </summary>
    public interface INHibernateConfiguration
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configiuration.</value>
        global::NHibernate.Cfg.Configuration Config { get; set; }

        /// <summary>
        /// Builds the session factory.
        /// </summary>
        /// <returns></returns>
        ISessionFactory BuildSessionFactory();
    }
}