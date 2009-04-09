namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Base repository for NHibernate aware repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TEntity> : BaseGenericRepository<TEntity, INHibernateRepository<TEntity>> where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected BaseRepository(INHibernateRepository<TEntity> repository) : base(repository)
        {
        }
    }
}