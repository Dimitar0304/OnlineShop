using Moq;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class GarmentServiceMock
    {
        public static IGarmentService Instance
        {
            get
            {
                var garmentService = new Mock<IGarmentService>();



                return garmentService.Object;
             }

        }
    }
}
