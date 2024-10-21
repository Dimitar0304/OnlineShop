namespace OnlineShop.Core.Models.AllClothes
{
    public class AllClothesViewModel
    {
        public List<ClothesViewModel> Clothes { get; set; } = new List<ClothesViewModel>();
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Term { get; set; } = null!;
    }
}
