using MyTobaccoShop.Data;
using MyTobaccoShop.Repository;
using MyTobaccoShop.Repository.RepositoriesImpl;
using System.Collections.Generic;
using System.Linq;

namespace MyTobaccoShop.Logic
{

    /// <summary>
    /// User Logic class.
    /// </summary>
    public class UserLogic
    {
        private IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// </summary>
        /// <param name="userRepository">User repository obj.</param>
        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// </summary>
        public UserLogic()
        {
            this.userRepository = new UserRepository(new ShopDatabaseEntities());
        }

        /// <summary>
        /// Get Admin Users mehtod.
        /// </summary>
        /// <returns>Admin Users.</returns>
        public List<GetAdminUser> GetAdminUsers()
        {
            var q = from user in this.userRepository.GetAll()
                    where user.U_TYPE == "Admin"
                    select new GetAdminUser()
                    {
                        User_type = user.U_TYPE,
                        Name = user.U_FULLNAME,
                    };
            return q.ToList();
        }

        /// <summary>
        /// Get User By username.
        /// </summary>
        /// <param name="username">user username.</param>
        /// <returns>user.</returns>
        public IQueryable<UserTable> GetUser(string username)
        {
            var q = from user in this.userRepository.GetAll()
                    where user.U_USERNAME.ToUpper() == username.ToUpper()
                    select user;
            return q;
        }

       /// <summary>
       /// Get All Users.
       /// </summary>
       /// <returns></returns>
        public IQueryable<UserTable> GetAll()
        {
            var q = from user in this.userRepository.GetAll()
                   select user;
            return q;
        }
    }
}
