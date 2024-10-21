using OnlineShop.Models.Brand;

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
