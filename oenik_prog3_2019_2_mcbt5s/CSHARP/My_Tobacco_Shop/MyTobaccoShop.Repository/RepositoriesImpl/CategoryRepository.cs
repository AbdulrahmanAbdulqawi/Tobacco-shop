using MyTobaccoShop.Data;
using System.Data.Entity;
using System.Linq;

namespace MyTobaccoShop.Repository.RepositoriesImpl
{
    /// <summary>
    /// Category class to implement the repository class.
    /// </summary>
    public class CategoryRepository : Repository<CategoryTable>, ICategoriesRepository
    {
        private ShopDatabaseEntities databaseEntities = new ShopDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public CategoryRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// add new Category to Category Table.
        /// </summary>
        /// <param name="entity">new Category.</param>
        public override void Add(CategoryTable entity)
        {
            this.databaseEntities.CategoryTables.Add(entity);
            this.ctx.SaveChanges();

        }

        /// <summary>
        /// Get Category By Id.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <returns>Category.</returns>
        public override CategoryTable GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CA_ID == id);
        }

        /// <summary>
        /// Remove Category from Category Table.
        /// </summary>
        /// <param name="entity">Category.</param>
        public override void Remove(CategoryTable entity)
        {
            this.databaseEntities.CategoryTables.Remove(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Update Category in Category table.
        /// </summary>
        /// <param name="entity">Category.</param>
        /// <param name="id">Category id.</param>
        public override void Update(CategoryTable entity, int id)
        {
            var oldUser = this.GetById(id);
            this.databaseEntities.CategoryTables.Remove(oldUser);
            this.databaseEntities.CategoryTables.Add(entity);
            this.ctx.SaveChanges();
        }
    }
}
