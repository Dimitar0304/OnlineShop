namespace OnlineShop.Core.Models.CartItem
{
    public class CartItem
    {
        public string CartItemId { get; set; } = null!;
        public Product.Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
