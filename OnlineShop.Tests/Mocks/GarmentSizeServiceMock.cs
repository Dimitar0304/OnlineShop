using Moq;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class GarmentSizeServiceMock
    {
        public static Mock<IGarmentSizeService> Instance()
        {
            return new Mock<IGarmentSizeService>();
        }
    }
}
