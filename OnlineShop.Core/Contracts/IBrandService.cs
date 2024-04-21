using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Models.AllClothes;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Contracts
{
    public interface  IBrandService
    {
        public Task<List<BrandViewModel>> GetAllBrands();

        public Task<List<GarmentViewModel>> GetGarmentsForCurrentBrand(int brandId);
        public Task<List<AccessoryAddViewModel>> GetAccessoriesForCurrentBrand(int brandId);
        public Task<List<ShoeAddViewModel>>GetShoesForCurrentBrand(int brandId);
        public Task<List<ClothesViewModel>> GetClothesForCurrentBrand(int currentBrandId);
        public Task<BrandViewModel> GetBrandById(int id);
    }
}
