using Moq;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.GarmentService;

namespace OnlineShop.Tests.Controllers
{
    [TestFixture]
    public class GarmentControllerTests
    {
        
        private readonly Mock<IGarmentService> service=new Mock<IGarmentService>();
        private readonly Mock<IGarmentSizeService> sizeService = new Mock<IGarmentSizeService>();
                
        

        [Test]
        public void AllMethodShouldReturnPageWithGarments()
        {
            //arange 
            var controller = new GarmentController(service.Object, sizeService.Object);

            //act 
             var result = controller.All(1).Result;

            //assert
            Assert.That(result, Is.Positive);

        }
        
        

    }
}
