using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Contracts;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Core.Services.GarmentService
{
    public class GarmentSizeService : IGarmentSizeService
    {
        private readonly HttpContextAccessor context;
        private readonly IRepository repository;
        public GarmentSizeService(HttpContextAccessor _context,IRepository _repository)
        {
            repository = _repository;
            context= _context;
        }
        public Task AddGarmentToCart(GarmentSize model)
        {
           throw new NotImplementedException(); 
        }

        public async Task<List<GarmentSize>> GetAllGarments()
        {
            return await repository.All<GarmentSize>().ToListAsync();
        }
    }
}
