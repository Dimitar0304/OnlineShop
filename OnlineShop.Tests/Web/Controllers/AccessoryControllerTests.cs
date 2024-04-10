using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.AccessoryService;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Tests.Common;
using OnlineShop.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Web.Controllers
{
    
    public class AccessoryControllerTests
    {
        private readonly IAccessoryService accessoryService;
        private readonly ApplicationDbContext db;
        public AccessoryControllerTests()
        {
            accessoryService = AccessoryServiceMock.Instance;
            db = DatabaseMock.Instance;

            
        }
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

        [Test]
        public async Task AllActionShoudReturnAllView()
        {
            //Arrange
            var controller = new AccessoryController(accessoryService);

            //Act
            var result = controller.All().Result;
            var accessories = accessoryService.GetAllAccessoryAsync().Result;

            //Assert
            Assert.AreEqual(accessories.Count(), 1);
            Assert.AreEqual(result.GetType(), typeof(IActionResult));
        }
    }
}
