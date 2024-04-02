using Moq;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class AccessoryServiceMock
    {
        public static IAccessoryService Instance
        {
            get
            {
                var accessoryService = new Mock<IAccessoryService>();



                return accessoryService.Object;
            }

        }

    }
}
