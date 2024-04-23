using Moq;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Core.Models.AllClothes;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;
using OnlineShop.Tests.Common;
using OnlineShop.Tests.Mocks;

namespace OnlineShop.Tests.Web.Controllers
{
    public class AllClothesControllerTests
    {
        private readonly IAccessoryService accessoryService;
        private readonly Mock<IGarmentService> garmentService;
        private readonly IShoeService shoeService;
        public AllClothesControllerTests()
        {
            accessoryService = AccessoryServiceMock.Instance;
            
            shoeService = ShoeServiceMock.Instance;
            garmentService = new Mock<IGarmentService>();
        }


        [SetUp]
        public void SetUp()
        {
            garmentService.Setup(s => s.GetAllGarmentsAsync())
                .ReturnsAsync(new List<Models.Garment.GarmentViewModel>()
                {
                    new Models.Garment.GarmentViewModel()
                    {
                        Id = 1,
                        Name="YesSearchIt",
                        BrandId=1,
                        BrandName="Nike",
                        ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                        Color = TestConstants.GarmentConstants.Color,
                        Price = TestConstants.GarmentConstants.Price,
                        TypeId = TestConstants.GarmentConstants.TypeId
                    }
                });
        }

        [Test]
        public void ShowSearchedItemsShouWorkAndShowMachedItems()
        {
            //Arrange
            var controller = new AllClothesController(garmentService.Object, shoeService, accessoryService);

            //Act
            
            var result = controller.ShowSearchedItems("SearchIt", 1) as Microsoft.AspNetCore.Mvc.ViewResult;
            var models = result.Model as AllClothesViewModel;
            //Assert
            Assert.AreEqual(result.Model.GetType(),typeof(AllClothesViewModel));
            Assert.AreEqual(models.Clothes.Count, 1);

        }
    }
}
