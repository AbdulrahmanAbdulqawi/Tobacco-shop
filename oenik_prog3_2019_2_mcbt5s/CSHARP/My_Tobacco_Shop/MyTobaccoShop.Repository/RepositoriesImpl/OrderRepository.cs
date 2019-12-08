using MyTobaccoShop.Data;
using System.Data.Entity;
using System.Linq;

namespace MyTobaccoShop.Repository.RepositoriesImpl
{
    /// <summary>
    /// order class to implement repository class.
    /// </summary>
    public class OrderRepository : Repository<OrderTable>, IOrderRepository
    {
        private ShopDatabaseEntities databaseEntities = new ShopDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public OrderRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// add new Order to Order Table.
        /// </summary>
        /// <param name="entity">new Order.</param>
        public override void Add(OrderTable entity)
        {
            
            this.databaseEntities.OrderTables.Add(entity);
            this.ctx.SaveChanges();

        }

        /// <summary>
        /// Get Order By Id.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <returns>Orders.</returns>
        public override OrderTable GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.O_ID == id);
        }

        /// <summary>
        /// Remove Order from Order Table.
        /// </summary>
        /// <param name="entity">Order.</param>
        public override void Remove(OrderTable entity)
        {
            this.databaseEntities.OrderTables.Remove(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Update Order in Order table.
        /// </summary>
        /// <param name="entity">Order.</param>
        /// <param name="id">Order id.</param>
        public override void Update(OrderTable entity, int id)
        {
            var oldUser = this.GetById(id);
            this.databaseEntities.OrderTables.Remove(oldUser);
            this.databaseEntities.OrderTables.Add(entity);
            this.ctx.SaveChanges();
        }
    }
}
