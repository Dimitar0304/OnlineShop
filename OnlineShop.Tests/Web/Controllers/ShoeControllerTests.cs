using NUnit.Framework;
using OnlineShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Web.Controllers
{
    public class ShoeControllerTests
    {
        [Test]
        public void ControllerShoudBeOnlyForAuthorizedUsers()
        {
            //Arrange
            var controller = new ShoeController(null, null);

            //Act
            var atrributes = controller.GetType().GetCustomAttributes(true);

            //Assert
            atrributes.Any(a => a.GetType() == typeof(AuthorAttribute));
        }

        
    }
}
