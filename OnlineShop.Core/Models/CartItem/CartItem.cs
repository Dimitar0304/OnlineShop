namespace OnlineShop.Core.Models.CartItem
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Product.Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
