using Moq;
using MyTobaccoShop.Data;
using MyTobaccoShop.Logic.Products_Logic;
using MyTobaccoShop.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTobaccoShop.Logic.Test
{
    /// <summary>
    /// product logic Test.
    /// </summary>
    class ProductLogicTest
    {
        /// <summary>
        /// Test Get Avg Price.
        /// </summary>
        [Test]
        public void TestGetAveragePrices()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            List<ProductTable> products = new List<ProductTable>()
            {
                new ProductTable() { CATEGORY_ID = 1, P_PRICE = 400 },
                new ProductTable() { CATEGORY_ID = 2, P_PRICE = 500 },
                new ProductTable() { CATEGORY_ID = 3, P_PRICE = 1000},
            };

            List<GetAveragePrice> getAveragePrices = new List<GetAveragePrice>()
            {
                new GetAveragePrice()
                {
                    CategorytID = 1, AvgPrice = 400,
                },
                new GetAveragePrice()
                {
                    CategorytID = 2, AvgPrice = 500,
                },
                new GetAveragePrice()
                {
                    CategorytID = 3, AvgPrice = 1000,
                },
            };
            mock.Setup(repo => repo.GetAll()).Returns(products.AsQueryable());
            ProductLogic productLogic = new ProductLogic(mock.Object);
            var actual = productLogic.GetAveragePrices();
            Assert.That(actual, Is.EquivalentTo(getAveragePrices));
            mock.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }

        /// <summary>
        /// Test GEt Product By ID.
        /// </summary>
        [Test]
        public void TestGetProductById()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>(MockBehavior.Loose);
            List<ProductTable> products = new List<ProductTable>()
            {
                new ProductTable()
                {
                    P_ID = 1,
                    P_NAME = "p1",
                },
                new ProductTable()
                {
                    P_ID = 2,
                    P_NAME = "p2",
                },
            };
            mock.Setup(repo => repo.GetAll()).Returns(products.AsQueryable());
            ProductLogic productLogic = new ProductLogic(mock.Object);
            var result = productLogic.GetProductById(1);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.Select(x => x.P_ID), Does.Contain(1));
            mock.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Test Update produxt
        /// </summary>
        [Test]
        public void TestAddProduct()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.GetAll());
            ProductTable product = new ProductTable()
            {
                P_ID = 3,
                P_NAME = "p3",
            };
            ProductLogic productLogic = new ProductLogic(mock.Object);
            productLogic.Add(product);
            mock.Verify(repo => repo.Add(It.Is<ProductTable>(x => x.P_ID == 3)));
        }

        /// <summary>
        /// Test Update Product.
        /// </summary>
        [Test]
        public void TestUpdateProduct()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.GetAll());
            List<ProductTable> products = new List<ProductTable>()
            {
                new ProductTable() { P_ID = 1, P_NAME = "p1" },
                new ProductTable() { P_ID = 2, P_NAME = "p2" },
                new ProductTable() { P_ID = 3, P_NAME = "p3"},
            };
            ProductLogic productLogic = new ProductLogic(mock.Object);
            productLogic.Update(
                new ProductTable()
            {
                P_ID = 4,
                P_NAME = "p4",
            }, 1);
            mock.Verify(repo => repo.Update(It.Is<ProductTable>(x => x.P_NAME == "p4"),1));
        }

    }

}
