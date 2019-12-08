using MyTobaccoShop.Data;

namespace MyTobaccoShop.Repository
{
    /// <summary>
    /// User Interface inherit from repository interface.
    /// </summary>
    public interface IUserRepository : IRepository<UserTable>
    {
        /// <summary>
        /// Update the type of the user.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="type">User Type.</param>
        void UpdateUserType(int id, string type);
    }
}
