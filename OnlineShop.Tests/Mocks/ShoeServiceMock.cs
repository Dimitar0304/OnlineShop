using Moq;
using OnlineShop.Core.Models.Type;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Tests.Common;

namespace OnlineShop.Tests.Mocks
{
    public static class ShoeServiceMock
    {
        public static IShoeService Instance
        {
            get
            {
                var shoeService = new Mock<IShoeService>();

                shoeService.Setup(s => s.GetAllShoeAsync())
                    .ReturnsAsync(new List<Core.Models.Shoe.ShoeAddViewModel>()
                    {
                        new Core.Models.Shoe.ShoeAddViewModel()
                        {
                            Id =1,
                            BrandId = TestConstants.ShoeConstants.BrandId,
                            BrandName = "Nike",
                            Color = TestConstants.ShoeConstants.Color,
                            ImageUrl = TestConstants.ShoeConstants.ImageUrl,
                            Price =TestConstants.ShoeConstants.Price,
                            Name = TestConstants.ShoeConstants.Name,
                            TypeId = TestConstants.ShoeConstants.TypeId

                        }
                    });

                shoeService.Setup(s => s.GetByIdAsync(1))
                    .ReturnsAsync(new Core.Models.Shoe.ShoeAddViewModel()
                    {
                        Id = 1,
                        Name = TestConstants.ShoeConstants.Name,
                        BrandName = "Nike",
                        BrandId = TestConstants.ShoeConstants.BrandId,
                        Color = TestConstants.ShoeConstants.Color,
                        ImageUrl = TestConstants.ShoeConstants.ImageUrl,
                        Price = TestConstants.ShoeConstants.Price,
                        TypeId = TestConstants.ShoeConstants.TypeId

                    });

                //setup service method getTypes
                shoeService.Setup(s => s.GetTypes())
                    .Returns(new List<TypeAllViewModel>()
                    {
                        new TypeAllViewModel()
                        {
                            Id = 2,
                            Name = "Shirt"
                        }
                    });

                return shoeService.Object;
            }

        }
    }
}
