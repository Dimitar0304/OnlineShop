﻿using OnlineShop.Models.Brand;
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
        Task AddGarmentToDbAsync(GarmentViewModel model);
        Task UpdateGarmentToDbAsync(GarmentViewModel model);
        void DeleteGarmentToDbAsync(int id);
        Task<List<GarmentViewModel>> GetAllGarmentsAsync();
        Task<GarmentViewModel> GetByIdAsync(int id);
        public Task<List<BrandViewModel>> GetBrands();
        public Task<List<SizeViewModel>> GetSizes();
    }
}
