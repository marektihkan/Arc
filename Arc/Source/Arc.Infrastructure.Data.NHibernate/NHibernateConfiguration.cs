using Arc.Infrastructure.Data.NHibernate.Listeners;
using NHibernate;
using NHibernate.Event;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Configuration for NHibernate.
    /// </summary>
    public class NHibernateConfiguration : INHibernateConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateConfiguration"/> class.
        /// </summary>
        public NHibernateConfiguration()
        {
            var configuration = new global::NHibernate.Cfg.Configuration();
            configuration.SetListener(ListenerType.PreInsert, new PreInsertEventListener());
            configuration.SetListener(ListenerType.PreUpdate, new PreUpdateEventListener());
            Config = configuration.Configure();
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configiuration.</value>
        public global::NHibernate.Cfg.Configuration Config { get; set; }

        /// <summary>
        /// Builds the session factory.
        /// </summary>
        /// <returns></returns>
        public ISessionFactory BuildSessionFactory( )
        {
            return Config.BuildSessionFactory();
        }
    }
}