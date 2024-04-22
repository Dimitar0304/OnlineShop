using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Models.Garment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Cart
{
    public class CartViewModel
    {
        public List<GarmentSizeViewModel>  Garments { get; set; }=new List<GarmentSizeViewModel>();
        public List<ShoeSizeViewModel> Shoes { get; set; } = new List<ShoeSizeViewModel>();
        public List<AccessoryAddViewModel> Accessories { get; set; } = new List<AccessoryAddViewModel>();
        public decimal TotalPrice { get; set; }
    }
}
