using Moq;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class ShoeServiceMock
    {
        public static IShoeService Instance
        {
            get
            {
                var shoeService = new Mock<IShoeService>();



                return shoeService.Object;
            }

        }
    }
}
