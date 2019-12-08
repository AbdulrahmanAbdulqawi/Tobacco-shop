using System.Linq;
using System.Data.Entity;

namespace MyTobaccoShop.Repository.RepositoriesImpl
{
    /// <summary>
    /// Repository abstract class inherit from repository interface.
    /// </summary>
    /// <typeparam name="T">T is class.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// Initializes a new instance of the DbContext.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// abstract method to Add a new entity, the implmentation will be in every specific class.
        /// </summary>
        /// <param name="entity">new entity.</param>
        public abstract void Add(T entity);

        /// <summary>
        /// Return all entities.
        /// </summary>
        /// <returns>entities.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Return an antity that match the id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>entity.</returns>
        public abstract T GetById(int id);

        /// <summary>
        /// abstract method to Remove an old entity, the implmentation will be in every specific class.
        /// </summary>
        /// <param name="entity">Remove.</param>
        public abstract void Remove(T entity);

        /// <summary>
        /// abstract method to Update an entity, the implmentation will be in every specific class.
        /// </summary>
        /// <param name="entity">Update.</param>
        /// <param name="id">id.</param>
        public abstract void Update(T entity, int id);
    }
}
