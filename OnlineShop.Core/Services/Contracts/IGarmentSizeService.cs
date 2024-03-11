using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services.Contracts
{
    public interface IGarmentSizeService
    {
      public Task AddGarmentWithSizes(int garmentId);
    }
}
