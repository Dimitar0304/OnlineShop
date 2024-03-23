using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Models.Size;
using OnlineShop.Core.Models.Type;
using OnlineShop.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services.Contracts
{
    public interface IAccessoryService
    {
        Task AddAccessoryToDbAsync(AccessoryAddViewModel model);
        Task UpdateAccessoryToDbAsync(AccessoryAddViewModel model);
        void DeleteAccessoryToDbAsync(int id);
        Task<List<AccessoryAllViewModel>> GetAllAccessoryAsync();
        Task<AccessoryAddViewModel> GetByIdAsync(int id);
        public Task<List<BrandViewModel>> GetBrands();
        public bool AccessoryIsExistInDb(AccessoryAddViewModel model);
    }
}
