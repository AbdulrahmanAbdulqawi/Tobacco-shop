using MyTobaccoShop.Data;
using System.Data.Entity;
using System.Linq;

namespace MyTobaccoShop.Repository.RepositoriesImpl
{
    /// <summary>
    /// User class to implement the repository class. 
    /// </summary>
    public class UserRepository : Repository<UserTable>, IUserRepository
    {

        private ShopDatabaseEntities databaseEntities = new ShopDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public UserRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// add new user to User Table.
        /// </summary>
        /// <param name="entity">new user.</param>
        public override void Add(UserTable entity)
        {
            this.databaseEntities.UserTables.Add(entity);
            this.ctx.SaveChanges();

        }

        /// <summary>
        /// Get User By Id.
        /// </summary>
        /// <param name="id">user id.</param>
        /// <returns>user.</returns>
        public override UserTable GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.U_ID == id);
        }

        /// <summary>
        /// Remove User form User Table.
        /// </summary>
        /// <param name="entity">User.</param>
        public override void Remove(UserTable entity)
        {
            this.databaseEntities.UserTables.Remove(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Update User in user table.
        /// </summary>
        /// <param name="entity">user.</param>
        /// <param name="id">user id.</param>
        public override void Update(UserTable entity, int id)
        {
            var oldUser = this.GetById(id);
            this.databaseEntities.UserTables.Remove(oldUser);
            this.databaseEntities.UserTables.Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Update the User Type.
        /// </summary>
        /// <param name="id">user id.</param>
        /// <param name="type">new user type.</param>
        public void UpdateUserType(int id, string type)
        {
            var user = this.GetById(id);
            user.U_TYPE = type;
            this.ctx.SaveChanges();
        }
    }
}
