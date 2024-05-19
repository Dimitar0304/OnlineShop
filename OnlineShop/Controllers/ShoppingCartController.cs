using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models.ShoppingCart;
using OnlineShop.Extentions;

namespace OnlineShop.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService service;
        public ShoppingCartController(IShoppingCartService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(string productName, int quantity,decimal price,string brandName)
        {
           //var product = _context.Products.SingleOrDefault(p => p.ProductId == productName);

            var product = new Core.Models.Product.Product()
            {
                Name = productName,
                Quantity=+quantity,
                Price=price,
                BrandName = brandName
            };
            if (product != null)
            {
                var cart = GetCart();
                cart.AddItem(product, quantity);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(string productName)
        {
            var cart = GetCart();
            cart.RemoveItem(productName);
            SaveCart(cart);
            return RedirectToAction("Index");
        }
        //Add and remove to Cart action TO DO 
        private ShoppingCart GetCart()
        {
           var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            return cart;
        }
        private void SaveCart(ShoppingCart cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
    }
}
