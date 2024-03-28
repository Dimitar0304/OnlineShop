using OnlineShop.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Accessory
{
    public class AccessoryDetailsViewModel:IProductModel
    {
        public string Name { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
       
        

    }
}
