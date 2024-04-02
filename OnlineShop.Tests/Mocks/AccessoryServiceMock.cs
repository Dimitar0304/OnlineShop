using Moq;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class AccessoryServiceMock
    {
        public static Mock<IAccessoryService> Instance()
        {
            return  new Mock<IAccessoryService>();
        }

        
    }
}
