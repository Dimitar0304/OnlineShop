using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Models.Type;
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
        public Task AddGarmentToDbAsync(ShoeAddViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteGarmentToDbAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoeAddViewModel>> GetAllGarmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandViewModel>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<ShoeAddViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SizeViewModel>> GetSizes()
        {
            throw new NotImplementedException();
        }

        public Task<List<TypeAllViewModel>> GetTypes()
        {
            throw new NotImplementedException();
        }

        public Task UpdateGarmentToDbAsync(ShoeAddViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
