namespace OnlineShop.Core.Models.Accessory
{
    public class AllAccessoryViewModel
    {
        public List<AccessoryAllViewModel> Accessories { get; set; } = new List<AccessoryAllViewModel>();
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
