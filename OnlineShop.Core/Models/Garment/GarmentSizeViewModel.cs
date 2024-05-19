using OnlineShop.Core.Models.Size;
using OnlineShop.Models.Garment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Garment
{
    public class GarmentSizeViewModel:Product.Product
    {
        public GarmentViewModel Garment { get; set; } = null!;
        public SizeViewModel Size { get; set; } = null!;

        public int GarmentId { get; set; }
        public int SizeId { get; set; }
        public List<SizeViewModel> Sizes { get; set; } = new List<SizeViewModel>();
    }
}
