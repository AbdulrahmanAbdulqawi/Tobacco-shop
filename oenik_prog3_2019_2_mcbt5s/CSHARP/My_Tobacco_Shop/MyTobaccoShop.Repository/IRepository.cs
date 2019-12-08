using System.Linq;

namespace MyTobaccoShop.Repository
{
    /// <summary>
    /// repository interface.
    /// </summary>
    /// <typeparam name="T">T is class.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Add a new entity.
        /// </summary>
        /// <param name="entity">new entity.</param>
        void Add(T entity);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity">Update.</param>
        /// <param name="id">id.</param>
        void Update(T entity, int id);

        /// <summary>
        /// Remove an entity.
        /// </summary>
        /// <param name="entity">Remove.</param>
        void Remove(T entity);

        /// <summary>
        /// Return an antity that match the id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>entity.</returns>
        T GetById(int id);

        /// <summary>
        /// Return all entities.
        /// </summary>
        /// <returns>entities.</returns>
        IQueryable<T> GetAll();
    }
}
