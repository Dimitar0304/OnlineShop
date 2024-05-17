namespace OnlineShop.Core.Models.ShoppingCart
{
    public class ShoppingCart
    {
        public List<Product.Product> Items { get; set; } = new List<Product.Product>();
    }
}
