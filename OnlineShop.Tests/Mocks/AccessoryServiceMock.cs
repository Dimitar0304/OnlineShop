using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure;
using OnlineShop.Models.Brand;
using OnlineShop.Services.Contracts;
using OnlineShop.Tests.Common;
using System.Data;

namespace OnlineShop.Tests.Mocks
{
    public static class AccessoryServiceMock
    {
       

        public static IAccessoryService Instance
        {
            get
            {
                var accessoryService = new Mock<IAccessoryService>();
                var db = DatabaseMock.Instance;



                //setup service with accessory
                accessoryService.Setup(s => s.GetAllAccessoryAsync())
                    .ReturnsAsync(new List<AccessoryAllViewModel>()
                    {
                        new AccessoryAllViewModel()
                        {
                            Id = 1,
                            Name = TestConstants.AccessoryConstants.Name,
                            Type = TestConstants.AccessoryConstants.Type,
                            BrandName = "TestBrandName",
                            ImageUrl = TestConstants.AccessoryConstants.ImageUrl,
                            Price = TestConstants.AccessoryConstants.Price
                        }
                    });

                //setup service method getbyIdAsync
                accessoryService.Setup(s => s.GetByIdAsync(1))
                    .ReturnsAsync(new AccessoryAddViewModel()
                    {
                        Id = 1,
                        Name = TestConstants.AccessoryConstants.Name,
                        BrandId = 1,
                        BrandName = "Nike",
                        ImageUrl = TestConstants.AccessoryConstants.ImageUrl,
                        Price = TestConstants.AccessoryConstants.Price,
                        Type = TestConstants.AccessoryConstants.Type
                    });

                //setup service method getbrands
                accessoryService.Setup(s => s.GetBrands())
                    .ReturnsAsync(new List<BrandViewModel>()
                    {
                        new BrandViewModel()
                        {
                            Id =1,
                            Name = "Nike"
                        }
                    });
               


                return accessoryService.Object;
            }

        }

    }
}
