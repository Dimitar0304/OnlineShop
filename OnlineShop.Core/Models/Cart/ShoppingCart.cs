using OnlineShop.Core.Models.CartItem;




namespace OnlineShop.Core.Models.Cart;
public class ShoppingCart
{
    public List<CartItem.CartItem> Items { get; set; } = new List<CartItem.CartItem>();

    public void AddItem(Product.Product product, int quantity)
    {
        var existingItem = Items.FirstOrDefault(i => i.Product.Name == product.Name);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            Items.Add(new CartItem.CartItem { Product = product, Quantity = quantity });
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
