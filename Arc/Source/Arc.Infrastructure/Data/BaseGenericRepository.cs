namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Base repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    public abstract class BaseGenericRepository<TEntity, TRepository> where TRepository : IRepository<TEntity> where TEntity : class
    {
        private readonly TRepository _repository;


        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected BaseGenericRepository(TRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Gets the inner repository.
        /// </summary>
        /// <value>The inner repository.</value>
        protected TRepository InnerRepository
        {
            get { return _repository; }
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        protected IUnitOfWork UnitOfWork
        {
            get { return InnerRepository.UnitOfWork; }
        }
    }
}