using Moq;
using MyTobaccoShop.Data;
using MyTobaccoShop.Logic.Customers_Logic;
using MyTobaccoShop.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MyTobaccoShop.Logic.Test
{
    /// <summary>
    /// Customer Logic Tests.
    /// </summary>
    class CustomerLogicTest
    {
        [Test]
        public void TestGetSumOfCustomers()
        {
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            int sumOfCustomers = 2;
            List<CustomerTable> customers = new List<CustomerTable>()
            {
                new CustomerTable()
                {
                    CU_ID = 1,
                    CU_NAME = "Abdulrahman",
                },
                new CustomerTable()
                {
                    CU_ID = 2,
                    CU_NAME = "Ali",
                },
            };
            mock.Setup(repo => repo.GetAll()).Returns(customers.AsQueryable());

            CustomerLogic customerLogic = new CustomerLogic(mock.Object);
            var actual = customerLogic.SumOfCustomers();
            Assert.That(actual, Is.EqualTo(sumOfCustomers));
        }
    }
}
