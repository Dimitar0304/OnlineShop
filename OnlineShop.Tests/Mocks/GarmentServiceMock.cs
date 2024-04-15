using Moq;
using OnlineShop.Core.Services.AccessoryService;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using OnlineShop.Tests.Common;
using X.PagedList;
using OnlineShop.Core.Models.Type;

namespace OnlineShop.Tests.Mocks
{
    public static class GarmentServiceMock
    {
        public static IGarmentService Instance
        {
            get
            {
                var garmentService = new Mock<IGarmentService>();


                garmentService.Setup(s => s.GetAllGarmentsAsync())
                    .ReturnsAsync(new List<GarmentViewModel>()
                    {
                        new GarmentViewModel()
                        {
                            Id = 1,
                            BrandName = "Nike",
                            BrandId = 1,
                            Color = TestConstants.GarmentConstants.Color,
                            Name = TestConstants.GarmentConstants.Name,
                            ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                            Price = TestConstants.GarmentConstants.Price,
                            TypeId = TestConstants.GarmentConstants.TypeId,

                        }
                    });

                garmentService.Setup(s => s.GetByIdAsync(1))
                    .ReturnsAsync(
                    new GarmentViewModel()
                    {
                        Id = 1,
                        BrandId = 1,
                        BrandName = "Nike",
                        Name = TestConstants.GarmentConstants.Name,
                        ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                        Color = TestConstants.GarmentConstants.Color,
                        Price = TestConstants.GarmentConstants.Price,
                        TypeId = TestConstants.GarmentConstants.TypeId

                    });
                //setup service method getbrands
                garmentService.Setup(s => s.GetBrands())
                    .ReturnsAsync(new List<BrandViewModel>()
                    {
                        new BrandViewModel()
                        {
                            Id =1,
                            Name = "Nike"
                        }
                    });

                //setup service method getTypes
                garmentService.Setup(s => s.GetTypes())
                    .ReturnsAsync(new List<TypeAllViewModel>()
                    {
                        new TypeAllViewModel()
                        {
                            Id = 2,
                            Name = "Shirt"
                        }
                    });




                return garmentService.Object;
             }

        }
    }
}
