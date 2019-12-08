using Moq;
using MyTobaccoShop.Data;
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
    /// User Logic Test.
    /// </summary>
    class UserLogicTest
    {
        /// <summary>
        /// Test Get Admin Users Mehod .
        /// </summary>
        [Test]
        public void TestGetAdminUsers()
        {
            Mock<IUserRepository> mockRep = new Mock<IUserRepository>();
            List<UserTable> users = new List<UserTable>()
            {
                new UserTable() { U_FULLNAME = "Abdulrahman Abdulqawi", U_TYPE = "Admin" },
            };
            List<GetAdminUser> getAdmins = new List<GetAdminUser>()
            {
                new GetAdminUser() { Name = "Abdulrahman Abdulqawi", User_type = "Admin" },
            };
            mockRep.Setup(x => x.GetAll()).Returns(users.AsQueryable());
            UserLogic userLogic = new UserLogic(mockRep.Object);

            var actual = userLogic.GetAdminUsers();
            Assert.That(actual, Is.EquivalentTo(getAdmins));
            mockRep.Verify(x => x.GetAll(), Times.Exactly(1));
        }

        /// <summary>
        /// Test Get Users By Username.
        /// </summary>
        [Test]
        public void TestGetUsersByUsername()
        {
            Mock<IUserRepository> mockRep = new Mock<IUserRepository>();
            List<UserTable> users = new List<UserTable>()
            {
                new UserTable() { U_FULLNAME = "abdulrahman abdulqawi", U_USERNAME = "abdul" },
                new UserTable() { U_FULLNAME = "nizar", U_USERNAME = "nizar2017" },
            };
            mockRep.Setup(x => x.GetAll()).Returns(users.AsQueryable());
            UserLogic userLogic = new UserLogic(mockRep.Object);
            var result = userLogic.GetUser("abdul");
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.Select(x => x.U_FULLNAME), Does.Contain("abdulrahman abdulqawi"));
            mockRep.Verify(repo => repo.GetAll(), Times.Once);
            mockRep.Verify(repo => repo.Add(It.IsAny<UserTable>()), Times.Never);
        }

        /// <summary>
        /// Test Get All Users.
        /// </summary>
        [Test]
        public void TestGetAllUsers()
        {
            Mock<IUserRepository> mockRep = new Mock<IUserRepository>();
            List<UserTable> users = new List<UserTable>()
            {
                new UserTable() { U_FULLNAME = "abdulrahman abdulqawi", U_USERNAME = "abdul" },
                new UserTable() { U_FULLNAME = "nizar", U_USERNAME = "nizar2017" },
            };
            mockRep.Setup(x => x.GetAll()).Returns(users.AsQueryable());
            UserLogic userLogic = new UserLogic(mockRep.Object);
            var result = userLogic.GetAll();
            Assert.That(result.Count(), Is.EqualTo(2));
            mockRep.Verify(repo => repo.GetAll(), Times.Once);
            mockRep.Verify(repo => repo.Add(It.IsAny<UserTable>()), Times.Never);
        }
    }
}
