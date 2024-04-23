using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models.Cart;
using OnlineShop.Extentions;

namespace OnlineShop.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IHttpContextAccessor context;
        public OrderController(IOrderService _orderService, IHttpContextAccessor context)
        {
            orderService = _orderService;
            this.context = context;

        }
        public async  Task<IActionResult> Cart(CartViewModel context)
        {
            //var model = context.HttpContext.Items["Cart"] as CartViewModel;
            if (context!=null)
            {
                return View(context);
            }
            return RedirectToAction("Index","Home",new {Area=""});
        }
    }
}
