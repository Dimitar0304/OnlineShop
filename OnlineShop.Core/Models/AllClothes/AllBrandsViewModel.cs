using OnlineShop.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.AllClothes
{
    public class AllBrandsViewModel
    {
        public List<BrandViewModel> Brands { get; set; }=new List<BrandViewModel>();
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
