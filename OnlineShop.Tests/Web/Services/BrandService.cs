using NUnit.Framework;
using OnlineShop.Core.Contracts;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Tests.Mocks;
using OnlineShop.Infrastructure.Data.Models;
namespace OnlineShop.Tests.Web.Services
{
    [TestFixture]
    public class BrandService
    {
        private IBrandService service;
        private ApplicationDbContext context;
        [SetUp]
        public void SetUp()
        {

            context = DatabaseMock.Instance;
            IRepository repository = new Infrastructure.Common.Repository(context);

            service = new OnlineShop.Core.Services.BrandService.BrandService(repository);
        }
        [Test]
        public void GetAllBrandsMethodShoudReturnAllBrandsInDb()
        {
            //Act
            var brands = service.GetAllBrands().Result;
            //Assert
            Assert.AreEqual(1, brands.Count);   
            Assert.AreEqual("Nike",brands.First().Name);
        }
        [Test]
        public void GetBrandByIdWithWrongIdShoudReturnNull()
        {
            //Act
            var brand = service.GetBrandById(50550505).Result;

            //Assert
            Assert.AreEqual(brand,null);
        }
        [Test]
        public void GetBrandByIdShoudReturnCorrectBrandType()
        {
            //Act
            var brand = service.GetBrandById(1).Result;

            //Assert
            Assert.AreEqual(brand.Name, "Nike");
        }
        [Test]
        public void GetClothesForWrongIdShoudReturnEmptyModel()
        {
            //Act
            var model = service.GetClothesForCurrentBrand(30304040).Result;

            //Assert
            Assert.AreEqual(model.Count, 0);
        }
        [Test]
        public void GetClothesForBrandShoudReturnCorrectClothes()
        {
            //Act
            var model = service.GetClothesForCurrentBrand(1).Result;

            //Assert
            Assert.AreEqual(model.Count(), 3);
        }
        [Test]
        public void GetAllGarmentsForCurrentBrandWithWrongBrandShoudReturnEmptyModel()
        {
            //Act
            var model = service.GetGarmentsForCurrentBrand(123232).Result;


            //Assert
            Assert.AreEqual(model.Count,0); 
        }
        [Test]
        public void GetAllGarmentsShoudReturnCorrectGarment()
        {
            //Act
            var model = service.GetGarmentsForCurrentBrand(1).Result;

            //Assert
            Assert.AreEqual(model.Count, 1);
            Assert.AreEqual(model.First().BrandId, 1);
        }
        [Test]
        public void GetAllAccessoriesForCurrentBrandWithWrongBrandShoudReturnEmptyModel()
        {
            //Act
            var model = service.GetAccessoriesForCurrentBrand(123232).Result;


            //Assert
            Assert.AreEqual(model.Count, 0);
        }
        [Test]
        public void GetAllAccessoriesShoudReturnCorrectAccessories()
        {

            //Act
            var model = service.GetAccessoriesForCurrentBrand(1).Result;

            //Assert
            Assert.AreEqual(model.Count, 1);
            Assert.AreEqual(model.First().BrandId, 1);
        }
        [Test]
        public void GetAllShoesForCurrentBrandWithWrongBrandShoudReturnEmptyModel()
        {
            //Act
            var model = service.GetAccessoriesForCurrentBrand(123232).Result;


            //Assert
            Assert.AreEqual(model.Count, 0);
        }
        [Test]
        public void GetAllShoesShoudReturnCorrectShoes()
        {
            //Act
            var model = service.GetShoesForCurrentBrand(1).Result;

            //Assert
            Assert.AreEqual(model.Count, 1);
            Assert.AreEqual(model.First().BrandId, 1);
        }
        [TearDown]
        public void TearDown()
        {
            service = null;
        }
    }
}
