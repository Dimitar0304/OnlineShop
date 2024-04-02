using Moq;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Tests.Mocks
{
    public static class ShoeServiceMock
    {
        public static Mock<IShoeService> Instance()
        {
            return new Mock<IShoeService>();
        }
    }
}
