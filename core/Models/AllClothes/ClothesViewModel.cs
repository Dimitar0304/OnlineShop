namespace OnlineShop.Core.Models.AllClothes
{
    //class that is for each clothes in shop
    public class ClothesViewModel
    {
        public string ClothesType { get; set; } = null!;
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; }=null!;
        public decimal Price { get; set; }
    }
}
