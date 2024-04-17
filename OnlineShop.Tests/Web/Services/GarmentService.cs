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
        [Test]
        public async Task DeleteGarmentFromDbAsyncIfGarmentDoNotExist()
        {
            //Act
            await garmentService.DeleteGarmentToDbAsync(-3);

            //Assert
            Assert.AreEqual(context.Garments.Count(), 1);
        }
        [Test]
        public async Task DeleteGarmentFromDbAsyncCorrectly()
        {
            //Act
            await garmentService.DeleteGarmentToDbAsync(1);

            //Assert
            Assert.AreEqual(context.Garments.Count(), 0);
        }

        [Test]
        public async Task AllMethodShoudReturnAllGarments()
        {
            //Act
            var models = await garmentService.GetAllGarmentsAsync();

            //Assert
            Assert.IsNotNull(models);
            Assert.AreEqual(models.GetType(), typeof(List<GarmentViewModel>));
        }

        [Test]
        public async Task UpdateGarmentWithNullRefModelShoudNotUpdateIt()
        {
            //Arrange
            GarmentViewModel model = null;

            //Act
            await garmentService.UpdateGarmentToDbAsync(model);

            //Assert
            Assert.AreNotEqual(model, await garmentService.GetByIdAsync(1));
        }
        [Test]
        public async Task UpdateGarmentWithCorrectModelShoudUpdateIt()
        {
            //Arrange
            var model = new GarmentViewModel()
            {
                Id = 1,
                Name = "MyTestEdited",
                BrandId = 1,
                TypeId =1,
                Color = "Edit",
                ImageUrl  ="Edit",
                Price = TestConstants.GarmentConstants.Price
                
            };

            //Act
            await garmentService.UpdateGarmentToDbAsync(model);

            //Assert
            Assert.AreEqual(garmentService.GetByIdAsync(1).Result.Name, "MyTestEdited");
        }
        [Test]
        public async Task GetBrandsMethod()
        {
            //Act
            var brands = await garmentService.GetBrands();

            //Assert
            Assert.AreEqual(brands.Count, 1);
            Assert.AreEqual(brands.First().Name, "Nike");
        }
        [Test]
        public async Task GetSizesMethodTest()
        {
            //Act
            var sizes = await garmentService.GetSizes();

            //Assert
            Assert.AreEqual(sizes.Count, 1);
            Assert.AreEqual(sizes.First().Name, "S");
        }
        [Test]
        public async Task GetTypesMethodTest()
        {
            //Act
            var types = await garmentService.GetTypes();    

            //Assert
            Assert.AreEqual(types.Count, 1);
            Assert.AreEqual(types.First().Name, "Shirt");
        }
        [Test]
        public async Task IsGarmentExistWithNullModel()
        {
            //Arrange
            GarmentViewModel model = null;

            //Act
           var res =  await garmentService.IsGarmentExist(model);

            //Assert
            Assert.AreEqual(res, false);    
        }
        [Test]
        public async Task IsGarmentExistWithNotExistingModel()
        {
            //Arrange
            var model = new GarmentViewModel()
            {
                Name= "SomethingDiff",
                BrandId = 1,
                TypeId = 2,
                Color= TestConstants.GarmentConstants.Color,
                ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                Price = TestConstants.GarmentConstants.Price
                
            };
            //Act
            var res = await garmentService.IsGarmentExist(model);
            //Assert
            Assert.AreEqual(res, false);
        }
        [Test]
        public async Task IsGarmentExistWithExistingModel()
        {
            //Arrange
            var model = new GarmentViewModel()
            {
                Name = TestConstants.GarmentConstants.Name,
                BrandId =1,
                TypeId=2,
                Color = TestConstants.GarmentConstants.Color,
                Price = TestConstants.GarmentConstants.Price,
                ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                
            };

            //Act
            var res = await garmentService.IsGarmentExist(model);

            //Asseert
            Assert.AreEqual(res, true);
        }
        [Test]
        public async Task SoftDeletedIfIdIsInvalid()
        {
            //Act
            var activeGarmentsBeforeDelete = await garmentService.GetAllGarmentsAsync();
            await garmentService.SoftDelete(-2);
            var activeGarmentsAfterDelete = await garmentService.GetAllGarmentsAsync();

            //Assert
            Assert.AreEqual(activeGarmentsBeforeDelete.Count(),activeGarmentsAfterDelete.Count());
        }
        [Test]
        public async Task SoftDeletedIfIdIsValid()
        {
            //Act
            var activeGarmentsBeforeDelete = await garmentService.GetAllGarmentsAsync();
            await garmentService.SoftDelete(1);
            var activeGarmentsAfterDelete = await garmentService.GetAllGarmentsAsync();

            //Assert
            Assert.AreNotEqual(activeGarmentsBeforeDelete.Count(), activeGarmentsAfterDelete.Count());
        }
        [TearDown]
        public void TearDown()
        {
            garmentService = null;
        }
    }
}