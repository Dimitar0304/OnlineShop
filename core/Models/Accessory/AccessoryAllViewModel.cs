﻿using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Core.Models.Accessory
{
    /// <summary>
    /// Accessory all view model for display all accessories
    /// </summary>
    public class AccessoryAllViewModel : IProductModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }
        public string BrandName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
