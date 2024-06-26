﻿using OnlineShop.Core.Models.Size;
using OnlineShop.Core.Models.Type;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;

namespace OnlineShop.Services.Contracts
{
    public interface IGarmentService
    {
        Task AddGarmentToDbAsync(GarmentViewModel model);
        Task UpdateGarmentToDbAsync(GarmentViewModel model);
        Task DeleteGarmentToDbAsync(int id);
        Task<List<GarmentViewModel>> GetAllGarmentsAsync();
        Task<GarmentViewModel> GetByIdAsync(int id);
        public  Task<List<BrandViewModel>> GetBrands();
        public Task<List<SizeViewModel>>GetSizes();
        public Task<List<TypeAllViewModel>> GetTypes();

        public Task AddGarmentWithSizeToDb(string sizeName,int garmentId);

        public Task<bool> IsGarmentExist(GarmentViewModel model);

        public Task<List<SizeViewModel>> GetSizeViewModels(int modelId);

        public decimal GetPriceByGarmentId(int garmentId);  

        public Task SoftDelete(int id);
    }
}
