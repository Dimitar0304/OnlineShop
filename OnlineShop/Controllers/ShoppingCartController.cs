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
