using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OnlineShop.Controllers;

namespace OnlineShop.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public  void RenderSearchBarShouldRetrunPartialView()
        {
            //arrange
            var controller = new HomeController(null);

            //act
            ViewResult result = controller.RenderSearchBar() as ViewResult;

            //assert 

            Assert.AreEqual(result.ViewName, "RenderSearchBar");
        }
    }
}
