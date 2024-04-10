using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OnlineShop.Controllers;

namespace OnlineShop.Tests.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void RenderSearchBarShouldRetrunPartialView()
        {
            //arrange
            var controller = new HomeController(null);

            //act
            ActionResult result = controller.RenderSearchBar();

            //assert 

            Assert.AreEqual(result.GetType().Name, "PartialViewResult");
        }
    }
}
