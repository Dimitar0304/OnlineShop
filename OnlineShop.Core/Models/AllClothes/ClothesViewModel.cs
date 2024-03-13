using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.AllClothes
{
    //class that is for each clothes in shop
    public class ClothesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; }=null!;
        public decimal Price { get; set; }
    }
}
