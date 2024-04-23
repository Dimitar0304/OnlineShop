using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Tests.Mocks;

namespace OnlineShop.Tests.Web.Controllers
{
    public class ShoeControllerTests
    {
        private readonly IShoeService service;
        public ShoeControllerTests()
        {
            service = ShoeServiceMock.Instance;
        }
        [Test]
        public void ControllerShoudBeOnlyForAuthorizedUsers()
        {
            //Arrange
            var controller = new ShoeController(null);

            //Act
            var atrributes = controller.GetType().GetCustomAttributes(true);

            //Assert
            atrributes.Any(a => a.GetType() == typeof(AuthorAttribute));
        }

        [Test]
        public void AllMethodWithShoesShoudReturnAllViewWithShoes()
        {
            //Arrange
            var controller = new ShoeController(service);

            //Act
            var result = controller.All(1);
            var asAct = result.Result as Microsoft.AspNetCore.Mvc.ViewResult;

            //Assert
            Assert.AreEqual(result.IsCompletedSuccessfully,true);
            Assert.IsNotNull(asAct.Model);
        }

        [Test]
        public void AllMethodWithoutShoesShouldReturnRedirectToAction()
        {
            //Arrange
            var emptyService = new Mock<IShoeService>();

            emptyService.Setup(s => s.GetAllShoeAsync())
                .ReturnsAsync(new List<Core.Models.Shoe.ShoeAddViewModel>()
                {

                });

            var controller = new ShoeController(emptyService.Object);

            //Act
            var result = controller.All(1).Result as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ControllerName, "Home");
            Assert.AreEqual(result.ActionName,"Index");
        }

        [Test]
        public void DetailsMethodShoudReturnInfoForCurrentShoe()
        {
            //Arrange
            var controller = new ShoeController(service);

            //Act
            var result = controller.Details(1, "ShoeTestNameNike").Result as ViewResult;

            //Assert
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(result.Model.GetType(), typeof(ShoeDetailsViewModel));
            

        }
        [Test]
        public void DetailsMethodWithWrongRootElmentsForInformationShouldReturnBadRequest()
        {
            //Arrange
            var controller = new ShoeController(service);

            //Act
            var result = controller.Details(1, "WrongInformation").Result as ActionResult;

            //Assert
            Assert.AreEqual(result.GetType(), typeof(BadRequestResult));
           
        }
        [Test]
        public void DetailsMethodWithWrongIdShoudReturnBadRequest()
        {
            //Arrange
            var controller = new ShoeController(service);

            //Act
            var result = controller.Details(4444, "ShoeTestNameNike").Result as ActionResult;

            //Assert
            Assert.AreEqual(result.GetType(), typeof(BadRequestResult));
        }
    }
}
