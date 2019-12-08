using MyTobaccoShop.Data;
using MyTobaccoShop.Repository;
using MyTobaccoShop.Repository.RepositoriesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTobaccoShop.Logic.Products_Logic
{
    /// <summary>
    /// Product Logic class.
    /// </summary>
    public class ProductLogic
    {
        private IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogic"/> class.
        /// </summary>
        /// <param name="userRepository">User repository obj.</param>
        public ProductLogic(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogic"/> class.
        /// </summary>
        public ProductLogic()
        {
            this.productRepository = new ProductRepository(new ShopDatabaseEntities());
        }

        /// <summary>
        /// Update Product Price.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <param name="newPrice">Product New Price.</param>
        public void UpdatePrice(int id, decimal newPrice)
        {
            this.productRepository.UpdatePrice(id, newPrice);
        }

        /// <summary>
        /// get average Price from product table.
        /// </summary>
        /// <returns>list with Category Names , and thier Avg Price.</returns>
        public IList<GetAveragePrice> GetAveragePrices()
        {
            var q = from product in this.productRepository.GetAll()
                    group product by product.CATEGORY_ID into g
                    select new GetAveragePrice()
                    {
                        CategorytID = g.Key,
                        AvgPrice = g.Average(p => p.P_PRICE),
                    };
            return q.ToList();
        }

        /// <summary>
        /// Get User By name.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Product mathc the Id.</returns>
        public IQueryable<ProductTable> GetProductById(int id)
        {
            var q = from p in this.productRepository.GetAll()
                    where p.P_ID == id
                    select p;
            return q;
        }

        /// <summary>
        /// Add a Product.
        /// </summary>
        /// <param name="product">prooduct Entity.</param>
        public void Add(ProductTable product )
        {
            this.productRepository.Add(product); 
        }

        /// <summary>
        /// Update Product.
        /// </summary>
        /// <param name="product">new product entity.</param>
        /// <param name="id">old product id.</param>
        public void Update(ProductTable product , int id)
        {
            this.productRepository.Update(product, id);
        }

        

    }
}
