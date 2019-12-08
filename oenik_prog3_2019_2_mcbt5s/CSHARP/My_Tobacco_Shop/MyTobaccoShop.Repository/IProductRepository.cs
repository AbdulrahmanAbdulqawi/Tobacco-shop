using MyTobaccoShop.Data;

namespace MyTobaccoShop.Repository
{
    /// <summary>
    /// Product interface inherit from Repository interface.
    /// </summary>
    public interface IProductRepository : IRepository<ProductTable>
    {
        /// <summary>
        /// Update the price of the product.
        /// </summary>
        /// <param name="id">product id.</param>
        /// <param name="price">product new price.</param>
        void UpdatePrice(int id, decimal price);
    }
}
