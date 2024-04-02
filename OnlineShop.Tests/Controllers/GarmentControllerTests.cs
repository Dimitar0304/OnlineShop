using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Tests.Mocks;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace OnlineShop.Tests.Controllers
{
    [TestFixture]
    public class GarmentControllerTests
    {
        
        [Test]
        public void AllMethodShouldReturnPageWithGarments()
        {
            //arange 
          
            var controller = new GarmentController(GarmentServiceMock.Instance,null);

            //act 
             var result = controller.All(1);

            //assert
            Assert.AreNotEqual(result, null);
            Assert.AreEqual(result.Result,Is.TypeOf<IActionResult>());
            
        }
        
        
        
        
        

    }
}
