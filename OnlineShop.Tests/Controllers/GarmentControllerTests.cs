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
        public  void AllMethodWithoutObjectsShouldReturnRedirectToActionResult()
        {
            //arange 
          
            var controller = 
                new GarmentController(GarmentServiceMock.Instance,GarmentSizeServiceMock.Instance);

            //act 
            
             var result =  controller.All(1).Result;

            //assert
            Assert.AreNotEqual(result, null);
            Assert.AreEqual(result,Is.TypeOf<ViewResult>());
            
        }
        
        
        
        
        

    }
}
