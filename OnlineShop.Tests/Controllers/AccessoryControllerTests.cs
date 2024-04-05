using Microsoft.AspNetCore.Authorization;
using NUnit.Framework;
using OnlineShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Controllers
{
    public class AccessoryControllerTests
    {
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
    }
}
