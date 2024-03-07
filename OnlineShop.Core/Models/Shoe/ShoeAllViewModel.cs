using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Shoe
{
    public class ShoeAllViewModel
    {

        public List<ShoeAddViewModel> Shoes { get; set; } = new List<ShoeAddViewModel>();
        public string Season { get; set; } = "Winter";
    }
}
