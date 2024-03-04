using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using OnlineShop.Models.Size;

namespace OnlineShop.Core.Services.ShoeService
{
    public class ShoeService : IShoeService
    {
        private readonly IRepository repository;
        public ShoeService(IRepository _repository)
        {
            repository = _repository;
        }
        public Task AddGarmentToDbAsync(GarmentViewModel model)
        {
            
        }

        public void DeleteGarmentToDbAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GarmentViewModel>> GetAllGarmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandViewModel>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<GarmentViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SizeViewModel>> GetSizes()
        {
            throw new NotImplementedException();
        }

        public Task UpdateGarmentToDbAsync(GarmentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
