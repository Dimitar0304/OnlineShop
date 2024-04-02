using Moq;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class GarmentSizeServiceMock
    {
        public static IGarmentSizeService Instance
        {
            get
            {
                var garmentSizeService = new Mock<IGarmentSizeService>();



                return garmentSizeService.Object;
            }

        }
    }
}
