using OnlineShop.Core.Models.Size;
using OnlineShop.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Shoe
{
    public class ShoeDetailsViewModel : IProductModel
    {
        public string Name { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string TypeName { get; set; }=null!;
        public List<SizeViewModel> AvailableSizes { get; set; } = new List<SizeViewModel>();
    }
}
