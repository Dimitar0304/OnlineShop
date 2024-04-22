using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models.Cart;
using OnlineShop.Extentions;

namespace OnlineShop.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        public async  Task<IActionResult> Cart(CartViewModel model)
        {
            if (model!=null)
            {
                return View(model);
            }
            return RedirectToAction("Index","Home",new {Area=""});
        }
    }
}
