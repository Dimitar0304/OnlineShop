using Moq;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Mocks
{
    public static class ShoeSizeServiceMock
    {
        public static IShoeSizeService Instance
        {
            get
            {
                var shoeSizeService = new Mock<IShoeSizeService>();



                return shoeSizeService.Object;
            }

        }
    }
}
