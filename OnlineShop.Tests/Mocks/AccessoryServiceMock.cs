using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure;
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

               


                return accessoryService.Object;
            }

        }

    }
}
