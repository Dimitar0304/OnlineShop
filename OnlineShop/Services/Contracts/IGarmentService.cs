using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using OnlineShop.Models.Size;

namespace OnlineShop.Services.Contracts
{
    public interface IGarmentService
    {
        Task AddGarmentToDbAsync(GarmentViewModel model);
        Task UpdateGarmentToDbAsync(GarmentViewModel model);
        void DeleteGarmentToDbAsync(int id);
        Task<List<GarmentViewModel>> GetAllGarmentsAsync();
        Task<GarmentViewModel> GetByIdAsync(int id);
        public  Task<List<BrandViewModel>> GetBrands();
        public Task<List<SizeViewModel>>GetSizes();
    }
}
