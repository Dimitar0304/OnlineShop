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
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
