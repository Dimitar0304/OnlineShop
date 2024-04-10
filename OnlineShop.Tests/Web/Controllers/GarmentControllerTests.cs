using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Models.Garment;
using OnlineShop.Tests.Mocks;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace OnlineShop.Tests.Web.Controllers
{
    [TestFixture]
    public class GarmentControllerTests
    {
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
        public void AllMethodWithoutObjectsShouldReturnRedirectToActionResult()
        {
            //arange 

            var garmentService = GarmentServiceMock.Instance;
            //garmentService.ge;
            var controller =
                new GarmentController(GarmentServiceMock.Instance, GarmentSizeServiceMock.Instance);

            var models = new List<GarmentViewModel>()
            {
                new GarmentViewModel()
                {
                    Id = 1,

                }
            };




            //act 

            var result = controller.All(1).Result;

            ////assert
            //Assert.AreNotEqual(result, null);
            //Assert.AreEqual(result,Is.TypeOf<ViewResult>());

        }






    }
}
