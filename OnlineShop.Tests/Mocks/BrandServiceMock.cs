using Moq;
using OnlineShop.Core.Contracts;
using OnlineShop.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Mocks
{
    public class BrandServiceMock
    {
        public static IBrandService Instance { get
            {
                var brandService = new Mock<IBrandService>();

                


                return brandService.Object;
            }
        }
    }
}
