using OnlineShop.Core.Models.Accessory;
using OnlineShop.Models.Brand;

namespace OnlineShop.Core.Services.Contracts
{
    public interface IAccessoryService
    {
        Task AddAccessoryToDbAsync(AccessoryAddViewModel model);
        Task UpdateAccessoryToDbAsync(AccessoryAddViewModel model);
        Task DeleteAccessoryToDbAsync(int id);
        Task<List<AccessoryAllViewModel>> GetAllAccessoryAsync();
        Task<AccessoryAddViewModel> GetByIdAsync(int id);
        public Task<List<BrandViewModel>> GetBrands();
        public bool AccessoryIsExistInDb(AccessoryAddViewModel model);
        public Task SoftDelete(int id);
    }
}
