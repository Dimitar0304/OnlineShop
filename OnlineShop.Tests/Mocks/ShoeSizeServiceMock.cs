using Moq;
using OnlineShop.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Mocks
{
    public static class ShoeSizeServiceMock
    {
        public static Mock<IShoeService> Instance()
        {
            return new Mock<IShoeService>();
        }
    }
}
