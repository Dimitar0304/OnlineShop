using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Models.Size;
using OnlineShop.Core.Models.Type;
using OnlineShop.Models.Brand;

namespace OnlineShop.Core.Services.Contracts
{
    public interface IShoeService
    {
        Task AddShoeToDbAsync(ShoeAddViewModel model);
        Task UpdateShoeToDbAsync(ShoeAddViewModel model);
        void DeleteShoeToDbAsync(int id);
        Task<List<ShoeAddViewModel>> GetAllShoeAsync();
        Task<ShoeAddViewModel> GetByIdAsync(int id);
        public List<BrandViewModel> GetBrands();
        public List<SizeViewModel> GetSizes();

        public List<TypeAllViewModel> GetTypes();
        public bool ShoeIsExistInDb(ShoeAddViewModel model);
        public  Task<List<SizeViewModel>> GetSizeViewModels(int shoeId);
    }
}
