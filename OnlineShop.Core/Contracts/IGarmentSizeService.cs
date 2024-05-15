using OnlineShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Contracts
{
    public interface IGarmentSizeService
    {
        public Task AddGarmentToCart(GarmentSize model);
        public Task<List<GarmentSize>> GetAllGarments();
    }
}
