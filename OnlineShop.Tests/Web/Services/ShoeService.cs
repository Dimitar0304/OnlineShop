using NUnit.Framework;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Tests.Common;
using OnlineShop.Tests.Mocks;

namespace OnlineShop.Tests.Web.Services
{
    public class ShoeService
    {
        private ApplicationDbContext context;
        private IShoeService shoeService;


        [SetUp]
        public void SetUp()
        {
            context = DatabaseMock.Instance;


            IRepository repository = new Infrastructure.Common.Repository(context);

            shoeService = new OnlineShop.Core.Services.ShoeService.ShoeService(repository);
        }
        [Test]
        public void GetByIdMethodWithWrongDataReturnsNull()
        {
            var entity = shoeService.GetByIdAsync(2).Result;

            Assert.IsNull(entity);
        }

        [Test]
        public async Task GetByIdMethodShoudReturnCorrectModel()
        {



            //Act
            var entities = context.Shoes.ToList();
            ShoeAddViewModel entity = shoeService.GetByIdAsync(1).Result;

            entity = entity;
            //Assert
            Assert.AreEqual(entity.Id, 1);
            Assert.AreEqual(entity.Name, TestConstants.ShoeConstants.Name);
        }

        [Test]
        public async Task AddShoeToDbAsyncWithWrongModel()
        {
            ShoeAddViewModel model = null;
            await shoeService.AddShoeToDbAsync(model);

            var shoes = context.Shoes.ToList();
            //Assert
            Assert.AreEqual(shoes.Count, 1);
        }
        [Test]
        public async Task AddShoeToDbAsyncWithCorrectModel()
        {
            var model = new ShoeAddViewModel()
            {
                Id = 2,
                BrandId = 1,
                TypeId = 2,
                Color = TestConstants.ShoeConstants.Color,
                ImageUrl = TestConstants.ShoeConstants.ImageUrl,
                Name = "SomethingDifferent",
                Price = TestConstants.ShoeConstants.Price

            };

            await shoeService.AddShoeToDbAsync(model);

            //Assert
            Assert.AreEqual(context.Shoes.Count(), 2);

        }
        [Test]
        public async Task DeleteShoeFromDbAsyncIfShoeDoNotExist()
        {
            //Act
            await shoeService.DeleteShoeToDbAsync(-3);

            //Assert
            Assert.AreEqual(context.Shoes.Count(), 1);
        }
        [Test]
        public async Task DeleteShoeFromDbAsyncCorrectly()
        {
            //Act
            await shoeService.DeleteShoeToDbAsync(1);

            //Assert
            Assert.AreEqual(context.Shoes.Count(), 0);
        }

        [Test]
        public async Task AllMethodShoudReturnAllShoes()
        {
            //Act
            var models = await shoeService.GetAllShoeAsync();

            //Assert
            Assert.IsNotNull(models);
            Assert.AreEqual(models.GetType(), typeof(List<ShoeAddViewModel>));
        }

        [Test]
        public async Task UpdateShoeWithNullRefModelShoudNotUpdateIt()
        {
            //Arrange
            ShoeAddViewModel model = null;

            //Act
            await shoeService.UpdateShoeToDbAsync(model);

            //Assert
            Assert.AreNotEqual(model, await shoeService.GetByIdAsync(1));
        }
        [Test]
        public async Task UpdateShoeWithCorrectModelShoudUpdateIt()
        {
            //Arrange
            var model = new ShoeAddViewModel()
            {
                Id = 1,
                Name = "MyTestEdited",
                BrandId = 1,
                TypeId = 1,
                Color = "Edit",
                ImageUrl = "Edit",
                Price = TestConstants.ShoeConstants.Price

            };

            //Act
            await shoeService.UpdateShoeToDbAsync(model);

            //Assert
            Assert.AreEqual(shoeService.GetByIdAsync(1).Result.Name, "MyTestEdited");
        }
        [Test]
        public  void GetBrandsMethod()
        {
            //Act
            var brands =  shoeService.GetBrands();

            //Assert
            Assert.AreEqual(brands.Count, 1);
            Assert.AreEqual(brands.First().Name, "Nike");
        }
       
        [Test]
        public void  GetTypesMethodTest()
        {
            //Act
            var types =  shoeService.GetTypes();

            //Assert
            Assert.AreEqual(types.Count, 1);
            Assert.AreEqual(types.First().Name, "Sneakers");
        }
       
        [Test]
        public async Task IsShoeExistWithNotExistingModel()
        {
            //Arrange
            var model = new ShoeAddViewModel()
            {
                Name = "SomethingDiff",
                BrandId = 1,
                TypeId = 2,
                Color = TestConstants.ShoeConstants.Color,
                ImageUrl = TestConstants.ShoeConstants.ImageUrl,
                Price = TestConstants.ShoeConstants.Price

            };
            //Act
            var res =  shoeService.ShoeIsExistInDb(model);
            //Assert
            Assert.AreEqual(res, false);
        }
        [Test]
        public async Task IsShoeExistWithExistingModel()
        {
            //Arrange
            var model = new ShoeAddViewModel()
            {
                Name = TestConstants.ShoeConstants.Name,
                BrandId = 1,
                TypeId = 2,
                Color = TestConstants.ShoeConstants.Color,
                Price = TestConstants.ShoeConstants.Price,
                ImageUrl = TestConstants.ShoeConstants.ImageUrl,

            };

            //Act
            var res =  shoeService.ShoeIsExistInDb(model);

            //Asseert
            Assert.AreEqual(res, true);
        }
        [Test]
        public async Task SoftDeletedIfIdIsInvalid()
        {
            //Act
            var activeGarmentsBeforeDelete = await shoeService.GetAllShoeAsync();
            await shoeService.SoftDelete(-2);
            var activeGarmentsAfterDelete = await shoeService.GetAllShoeAsync();

            //Assert
            Assert.AreEqual(activeGarmentsBeforeDelete.Count(), activeGarmentsAfterDelete.Count());
        }
        [Test]
        public async Task SoftDeletedIfIdIsValid()
        {
            //Act
            var activeGarmentsBeforeDelete = await shoeService.GetAllShoeAsync();
            await shoeService.SoftDelete(1);
            var activeGarmentsAfterDelete = await shoeService.GetAllShoeAsync();

            //Assert
            Assert.AreNotEqual(activeGarmentsBeforeDelete.Count(), activeGarmentsAfterDelete.Count());
        }
        [TearDown]
        public void TearDown()
        {
            shoeService = null;
        }
    }
}
