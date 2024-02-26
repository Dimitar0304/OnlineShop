﻿using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;

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
    }
}