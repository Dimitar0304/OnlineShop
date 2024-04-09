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
using OnlineShop.Tests.Mocks;
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

        [Test]
        public async Task AllMethodMustReturnAllViewName()
        {
            var accessory = new Accessory()
            {
                Id = 1,
                ImageUrl = "https://i.pinimg.com/564x/80/99/0a/80990a58b79edaf9ae83578d19a39a38.jpg",
                BrandId = 1,
                Quantity = 1,
                IsActive = true,
                Name = "Test",
                Price = 12.2m,
                Type = "Tests"
            };

            //arrange

            var dbContext = DatabaseMock.Instance;


            await dbContext.Accessories.AddAsync(accessory);
            await dbContext.SaveChangesAsync();

            Task<List<AccessoryAllViewModel>>models =  dbContext.Accessories.Select(a => new AccessoryAllViewModel()
            {
                BrandName = a.Brand.Name,
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                Name = a.Name,
                Price = a.Price,
                Type = a.Type.ToString()
            }).ToListAsync();



            var service = new Mock<IAccessoryService>();

             service.Setup(s => s.GetAllAccessoryAsync())
               .Returns(models);
               

            var controller = new AccessoryController(service.Object);

            //act
            var countOfAccessoriesInDb =  dbContext.Accessories.Where(a => a.Id == 1).ToListAsync().Result.Count;

            var countOfAccessories = service.Setups.First().Mock;

            var viewResult = controller.All().Result as ViewResult;

            //assert
            Assert.AreEqual(1, countOfAccessoriesInDb);

            //Assert.AreEqual(queryDb.GetType(), typeof(Accessory));
        }
    }
}
