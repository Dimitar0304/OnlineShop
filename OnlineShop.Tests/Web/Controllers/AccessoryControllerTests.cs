using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure;
using OnlineShop.Tests.Mocks;


namespace OnlineShop.Tests.Web.Controllers
{

    public class AccessoryControllerTests
    {
        private readonly IAccessoryService accessoryService;
        private readonly ApplicationDbContext db;
        public AccessoryControllerTests()
        {
            accessoryService = AccessoryServiceMock.Instance;
            db = DatabaseMock.Instance;

            
        }
        [Test]
        public void ControllerShouldBeOnlyForAuthorizedUsers()
        {
            //Arrange
            var controller = new AccessoryController(null);

            //Act
            var attributes = controller.GetType().GetCustomAttributes(true);

            //Assert
            attributes.Any(a => a.GetType() == typeof(AuthorizeAttribute));
        }

        [Test]
        public async Task AllActionShoudReturnAllAccessories()
        {
            //Arrange
            var controller = new AccessoryController(accessoryService);

            //Act
            var result = controller.All(1).Result as ViewResult;
            var accessories = accessoryService.GetAllAccessoryAsync().Result;

            //Assert
            Assert.AreEqual(accessories.Count(), 1);
            Assert.AreEqual(result.GetType(), typeof(ViewResult));
            Assert.NotNull(result.Model);
           
            
        }

        [Test]
        public async Task DetailsActionShoudReturnInfoForCurrentAccessory()
        {
            //Arrange
            var controller = new AccessoryController(accessoryService);
            

            //Act
            var result = controller.Details(1, "AccessoryTestNameNike").Result as ViewResult;
            var attributes = controller.GetType().GetCustomAttributes(true);

            //Assert
            attributes.Any(a => a.GetType() == typeof(System.Web.Mvc.HandleErrorAttribute));
            Assert.IsNotNull(result.Model);
            
            
        }
    }
}
