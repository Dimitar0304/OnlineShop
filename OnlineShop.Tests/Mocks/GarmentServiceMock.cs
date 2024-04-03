using Moq;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using X.PagedList;

namespace OnlineShop.Tests.Mocks
{
    public static class GarmentServiceMock
    {
        public static IGarmentService Instance
        {
            get
            {
                var garmentService = new Mock<IGarmentService>();

                var models = new List<GarmentViewModel>();

               

                return garmentService.Object;
             }

        }
    }
}
