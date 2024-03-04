using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Models.Type;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using OnlineShop.Models.Size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services.Contracts
{
    public interface IShoeService
    {
        Task AddGarmentToDbAsync(ShoeAddViewModel model);
        Task UpdateGarmentToDbAsync(ShoeAddViewModel model);
        void DeleteGarmentToDbAsync(int id);
        Task<List<ShoeAddViewModel>> GetAllGarmentsAsync();
        Task<ShoeAddViewModel> GetByIdAsync(int id);
        public Task<List<BrandViewModel>> GetBrands();
        public Task<List<SizeViewModel>> GetSizes();

        public Task<List<TypeAllViewModel>> GetTypes();
    }
}
