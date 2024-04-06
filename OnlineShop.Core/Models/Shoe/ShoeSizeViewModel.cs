using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Shoe
{
    public class ShoeSizeViewModel
    {

        public int ShoeId { get; set; }
        public string SizeName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
