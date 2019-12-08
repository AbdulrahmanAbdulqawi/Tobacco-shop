using MyTobaccoShop.Data;
using System.Data.Entity;
using System.Linq;

namespace MyTobaccoShop.Repository.RepositoriesImpl
{
    /// <summary>
    /// Customer class to implement the repository class. 
    /// </summary>
    public class CustomerRepository : Repository<CustomerTable>, ICustomerRepository
    {
        private ShopDatabaseEntities databaseEntities = new ShopDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public CustomerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// add new customer to customer Table.
        /// </summary>
        /// <param name="entity">new customer.</param>
        public override void Add(CustomerTable entity)
        {
            this.databaseEntities.CustomerTables.Add(entity);
            this.ctx.SaveChanges();

        }

        /// <summary>
        /// Get customer By Id.
        /// </summary>
        /// <param name="id">customer id.</param>
        /// <returns>customer.</returns>
        public override CustomerTable GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CU_ID == id);
        }

        /// <summary>
        /// Remove customer from customer Table.
        /// </summary>
        /// <param name="entity">customer.</param>
        public override void Remove(CustomerTable entity)
        {
            this.databaseEntities.CustomerTables.Remove(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Update Customer in customer table.
        /// </summary>
        /// <param name="entity">customer.</param>
        /// <param name="id">customer id.</param>
        public override void Update(CustomerTable entity, int id)
        {
            var oldUser = this.GetById(id);
            this.databaseEntities.CustomerTables.Remove(oldUser);
            this.databaseEntities.CustomerTables.Add(entity);
            this.ctx.SaveChanges();
        }
    }
}
