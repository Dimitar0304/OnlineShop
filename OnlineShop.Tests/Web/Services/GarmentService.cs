using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.GarmentService;
using OnlineShop.Tests.Common;
using OnlineShop.Tests.Mocks;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace OnlineShop.Tests.Web.Services
{
    [TestFixture]
    public class GarmentService
    {
        private ApplicationDbContext context;
        private IGarmentService garmentService;


        [SetUp]
        public void SetUp()
        {
            context = DatabaseMock.Instance;

           
            IRepository repository = new Infrastructure.Common.Repository(context);
           
            garmentService = new OnlineShop.Services.GarmentService.GarmentService(repository);
        }
        [Test]
        public void GetByIdMethodWithWrongDataReturnsNull()
        {
            var entity = garmentService.GetByIdAsync(2).Result;

            Assert.IsNull(entity);
        }

        [Test]
        public async Task GetByIdMethodShoudReturnCorrectModel()
        {
          
            
            
            //Act
            var entities = context.Garments.ToList();
            GarmentViewModel entity =  garmentService.GetByIdAsync(1).Result;

            entity = entity;
            //Assert
            Assert.AreEqual(entity.Id, 1);
            Assert.AreEqual(entity.Name, "GarmentTestName");
        }

        [Test]
        public async Task AddGarmentToDbAsyncWithWrongModel()
        {
            GarmentViewModel model =null;
            await garmentService.AddGarmentToDbAsync(model);
            
            var garments= context.Garments.ToList();
            //Assert
            Assert.AreEqual(garments.Count, 1);
        }
        [Test]
        public async Task AddGarmentToDbAsyncWithCorrectModel()
        {
            var model = new GarmentViewModel()
            {
                Id =2,
                BrandId = 1,
                TypeId =2,
                Color = TestConstants.GarmentConstants.Color,
                ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                Name = "SomethingDifferent",
                Price = TestConstants.GarmentConstants.Price
                
            };

            await garmentService.AddGarmentToDbAsync(model);

            //Assert
            Assert.AreEqual(context.Garments.Count(), 2);
           
        }
        [TearDown]
        public void TearDown()
        {
            garmentService = null;
        }
    }
}
