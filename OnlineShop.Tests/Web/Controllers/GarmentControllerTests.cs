using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Services.Contracts;
using OnlineShop.Tests.Mocks;


namespace OnlineShop.Tests.Web.Controllers
{
    [TestFixture]
    public class GarmentControllerTests
    {
        private readonly IGarmentService service;
        public GarmentControllerTests()
        {
            service = GarmentServiceMock.Instance;
        }
        [Test]
        public void ControllerShouldBeOnlyForAuthorizedUsersOnly()
        {
            //Arrange
            var controller = new GarmentController(null, null);

            //Act
            var attributes = controller.GetType().GetCustomAttributes(true);

            //Assert
            attributes.Any(a => a.GetType() == typeof(AuthorAttribute));
        }


        [Test]
        public void AllMethodWithObjectsShouldCompletlySuccsesfully()
        {
            //Arrange
            var controller = new GarmentController(service, null);

            //Act
            var result = controller.All(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.IsCompletedSuccessfully, true);
          
        }

        [Test]
        
        public void DetailsMethodShouldReturnAcionWithModel()
        {
            //Arrange
            var controller = new GarmentController(service, null);

            //Act
            var result = controller.Details(1, "GarmentTestNameNike");

            var attributes = result.GetType().GetCustomAttributes(true);
            
            //Assert
            Assert.AreEqual(result.IsCompletedSuccessfully, true);
            attributes.Any(a => a.GetType() == typeof(System.Web.Mvc.HandleErrorAttribute));


        }
        [Test]
        public void DetailsMethodWithWrongInformationMustThrowError()
        {
            //Arrange
            var controller = new GarmentController(service, null);

            //Act
            var result = controller.Details(1, "SomethingWrong").Result as ActionResult ;


            //Assert
            
            Assert.AreEqual(result.GetType(),typeof( BadRequestResult));
        }






    }
}
