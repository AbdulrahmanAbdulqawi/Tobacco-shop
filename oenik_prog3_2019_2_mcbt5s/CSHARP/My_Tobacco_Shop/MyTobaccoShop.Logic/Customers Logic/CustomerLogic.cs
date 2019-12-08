using MyTobaccoShop.Data;
using MyTobaccoShop.Repository;
using MyTobaccoShop.Repository.RepositoriesImpl;
using System.Linq;

namespace MyTobaccoShop.Logic.Customers_Logic
{
    /// <summary>
    /// Customer Logic class.
    /// </summary>
    public class CustomerLogic
    {
        private ICustomerRepository customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerLogic"/> class.
        /// </summary>
        /// <param name="userRepository">Customer repository obj.</param>
        public CustomerLogic(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerLogic"/> class.
        /// </summary>
        public CustomerLogic()
        {
            this.customerRepository = new CustomerRepository(new ShopDatabaseEntities());
        }

        /// <summary>
        /// How Many Customers in Customer table.
        /// </summary>
        /// <returns>Sum Number Of Customers.</returns>
        public int SumOfCustomers()
        {
            var q = this.customerRepository.GetAll().Count();
            return q;
        }

        /// <summary>
        /// Get Customer By Id.
        /// </summary>
        /// <param name="id">Customer id.</param>
        /// <returns>Customer.</returns>
        public CustomerTable GetCustomer(int id)
        {
            return this.customerRepository.GetById(id);
        }
    }
}
