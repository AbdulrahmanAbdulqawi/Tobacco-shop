using MyTobaccoShop.Data;
using System.Data.Entity;
using System.Linq;

namespace MyTobaccoShop.Repository.RepositoriesImpl
{
    /// <summary>
    /// product class to implement the repository class.
    /// </summary>
    public class ProductRepository : Repository<ProductTable>, IProductRepository
    {
        private ShopDatabaseEntities databaseEntities = new ShopDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public ProductRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// add new product to product Table.
        /// </summary>
        /// <param name="entity">new product.</param>
        public override void Add(ProductTable entity)
        {
            this.databaseEntities.ProductTables.Add(entity);
            this.ctx.SaveChanges();

        }

        /// <summary>
        /// Get product By Id.
        /// </summary>
        /// <param name="id">product id.</param>
        /// <returns>product.</returns>
        public override ProductTable GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.P_ID == id);
        }

        /// <summary>
        /// Remove product from product Table.
        /// </summary>
        /// <param name="entity">customer.</param>
        public override void Remove(ProductTable entity)
        {
            this.databaseEntities.ProductTables.Remove(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Update product in product table.
        /// </summary>
        /// <param name="entity">product.</param>
        /// <param name="id">product id.</param>
        public override void Update(ProductTable entity, int id)
        {
            var oldUser = this.GetById(id);
            this.databaseEntities.ProductTables.Remove(oldUser);
            this.databaseEntities.ProductTables.Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Update product price.
        /// </summary>
        /// <param name="id">product price.</param>
        /// <param name="price">new product price.</param>
        public void UpdatePrice(int id, decimal price)
        {
            var product = this.GetById(id);
            product.P_PRICE = price;
            this.ctx.SaveChanges();
        }
    }
}
