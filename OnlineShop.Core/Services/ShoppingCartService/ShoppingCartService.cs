using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models.CartItem;
using OnlineShop.Core.Models.Product;

namespace OnlineShop.Core.Services.ShoppingCartService
{
    public class ShoppingCartService:IShoppingCartService
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Name == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void RemoveItem(string productName)
        {
            Items.RemoveAll(i => i.Product.Name == productName);
        }

        public decimal GetTotal()
        {
            return Items.Sum(i => i.Product.Price * i.Quantity);
        }
    }
}
