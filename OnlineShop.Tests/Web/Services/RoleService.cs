using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Services.Contracts;
using OnlineShop.Tests.Mocks;

namespace OnlineShop.Tests.Web.Services
{
    [TestFixture]
    public class RoleService
    {
        private IRoleService service;
        private ApplicationDbContext context;
        private Microsoft.AspNetCore.Identity.UserManager<User> userManager;
        private Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;

        
        [SetUp]
        public void SetUp()
        {
            context = DatabaseMock.Instance;
           
            //service = new OnlineShop.Core.Services.RoleService.RoleService(userManager,roleManager);
        }
        [Test]
        public void TestAddUserToRoleShoudAddInUserRoleEnitites()
        {
           //Arrange
            service.AddUserToRole("a9cffa0c-1389-4bd3-abf5-43384a5df48a", "Admin");

            //Act
            var userRoleEntities = context.UserRoles;

            //Assert
            Assert.AreEqual(userRoleEntities.Count(),1);

        }
        [TearDown]
        public void TearDown()
        {
            context = null;
        }
    }
}
