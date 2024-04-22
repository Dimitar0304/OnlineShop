using NUnit.Framework;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Tests.Common;
using OnlineShop.Tests.Mocks;

namespace OnlineShop.Tests.Web.Services
{
    public class AccessoryService
    {
        private ApplicationDbContext context;
        private IAccessoryService accessoryService;


        [SetUp]
        public void SetUp()
        {
            context = DatabaseMock.Instance;


            IRepository repository = new Infrastructure.Common.Repository(context);

            accessoryService = new OnlineShop.Core.Services.AccessoryService.AccessoryService(repository);
        }
        [Test]
        public void GetByIdMethodWithWrongDataReturnsNull()
        {
            var entity = accessoryService.GetByIdAsync(2).Result;

            Assert.IsNull(entity);
        }

        [Test]
        public async Task GetByIdMethodShoudReturnCorrectModel()
        {



            //Act
            var entities = context.Garments.ToList();
            AccessoryAddViewModel entity = accessoryService.GetByIdAsync(1).Result;

            entity = entity;
            //Assert
            Assert.AreEqual(entity.Id, 1);
            Assert.AreEqual(entity.Name, TestConstants.AccessoryConstants.Name);
        }

        [Test]
        public async Task AddAccessoryToDbAsyncWithWrongModel()
        {
            AccessoryAddViewModel model = null;
            await accessoryService.AddAccessoryToDbAsync(model);

            var accessories = context.Garments.ToList();
            //Assert
            Assert.AreEqual(accessories.Count, 1);
        }
        [Test]
        public async Task AddAccessoryToDbAsyncWithCorrectModel()
        {
            var model = new AccessoryAddViewModel()
            {
                Id = 2,
                BrandId = 1,
                Type = TestConstants.AccessoryConstants.Type,
                
                ImageUrl = TestConstants.AccessoryConstants.ImageUrl,
                Name = "SomethingDifferent",
                Price = TestConstants.AccessoryConstants.Price

            };

            await accessoryService.AddAccessoryToDbAsync(model);

            //Assert
            Assert.AreEqual(context.Accessories.Count(), 2);

        }
        [Test]
        public async Task DeleteAccessoryFromDbAsyncIfAccessoryDoNotExist()
        {
            //Act
            await accessoryService.DeleteAccessoryToDbAsync(-3);

            //Assert
            Assert.AreEqual(context.Accessories.Count(), 1);
        }
        [Test]
        public async Task DeleteAccessoryFromDbAsyncCorrectly()
        {
            //Act
            await accessoryService.DeleteAccessoryToDbAsync(1);

            //Assert
            Assert.AreEqual(context.Accessories.Count(), 0);
        }

        [Test]
        public async Task AllMethodShoudReturnAllAccessories()
        {
            //Act
            var models = await accessoryService.GetAllAccessoryAsync();

            //Assert
            Assert.IsNotNull(models);
            Assert.AreEqual(models.GetType(), typeof(List<AccessoryAllViewModel>));
        }

        [Test]
        public async Task UpdateAccessoryWithNullRefModelShoudNotUpdateIt()
        {
            //Arrange
            AccessoryAddViewModel model = null;

            //Act
            await accessoryService.UpdateAccessoryToDbAsync(model);

            //Assert
            Assert.AreNotEqual(model, await accessoryService.GetByIdAsync(1));
        }
        [Test]
        public async Task UpdateAccessoryWithCorrectModelShoudUpdateIt()
        {
            //Arrange
            var model = new AccessoryAddViewModel()
            {
                Id = 1,
                Name = "MyTestEdited",
                BrandId = 1,
                Type = TestConstants.AccessoryConstants.Type,
                
                ImageUrl = "Edit",
                Price = TestConstants.AccessoryConstants.Price

            };

            //Act
            await accessoryService.UpdateAccessoryToDbAsync(model);

            //Assert
            Assert.AreEqual(accessoryService.GetByIdAsync(1).Result.Name, "MyTestEdited");
        }
        [Test]
        public async Task GetBrandsMethod()
        {
            //Act
            var brands = await accessoryService.GetBrands();

            //Assert
            Assert.AreEqual(brands.Count, 1);
            Assert.AreEqual(brands.First().Name, "Nike");
        }
        [Test]
        public  void IsAccessoryExistWithNotExistingModel()
        {
            //Arrange
            var model = new AccessoryAddViewModel()
            {
                Name = "SomethingDiff",
                BrandId = 1,
                Type = TestConstants.AccessoryConstants.Type,
              
                ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                Price = TestConstants.GarmentConstants.Price

            };
            //Act
            var res =  accessoryService.AccessoryIsExistInDb(model);
            //Assert
            Assert.AreEqual(res, false);
        }
        [Test]
        public  void IsAccessoryExistWithExistingModel()
        {
            //Arrange
            var model = new AccessoryAddViewModel()
            {
                Name = TestConstants.AccessoryConstants.Name,
                BrandId = 1,
                Type = TestConstants.AccessoryConstants.Type,
                
                Price = TestConstants.AccessoryConstants.Price,
                ImageUrl = TestConstants.AccessoryConstants.ImageUrl,

            };

            //Act
            var res =  accessoryService.AccessoryIsExistInDb(model);

            //Asseert
            Assert.AreEqual(res, true);
        }
        [Test]
        public async Task SoftDeletedIfIdIsInvalid()
        {
            //Act
            var activeGarmentsBeforeDelete = await accessoryService.GetAllAccessoryAsync();
            await accessoryService.SoftDelete(-2);
            var activeGarmentsAfterDelete = await accessoryService.GetAllAccessoryAsync();

            //Assert
            Assert.AreEqual(activeGarmentsBeforeDelete.Count(), activeGarmentsAfterDelete.Count());
        }
        [Test]
        public async Task SoftDeletedIfIdIsValid()
        {
            //Act
            var activeGarmentsBeforeDelete = await accessoryService.GetAllAccessoryAsync();
            await accessoryService.SoftDelete(1);
            var activeGarmentsAfterDelete = await accessoryService.GetAllAccessoryAsync();

            //Assert
            Assert.AreNotEqual(activeGarmentsBeforeDelete.Count(), activeGarmentsAfterDelete.Count());
        }
        [TearDown]
        public void TearDown()
        {
            accessoryService = null;
        }
    }
}
