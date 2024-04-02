using Moq;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class GarmentServiceMock
    {
        public static Mock<IGarmentService> Instance()
        {
            return new Mock<IGarmentService> ();
        }
    }
}
