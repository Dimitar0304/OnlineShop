using OnlineShop.Core.Models.Size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Garment
{
    /// <summary>
    /// Garment details view model
    /// </summary>
    public class GarmentDetailsViewModel
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public string Color { get; set; } = null!;
        public List<SizeViewModel> AvailableSizes { get; set; } = new List<SizeViewModel>();

    }
}
