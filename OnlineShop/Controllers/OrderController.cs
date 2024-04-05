using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Contracts;
using OnlineShop.Extentions;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        public async  Task<IActionResult> Cart()
        {
            if (await orderService.GetAllOrdersByUserId(ClaimsPrincipalExtentions.Id(this.User))==null)
            {
                return RedirectToAction("Index", "Home");
            }

            var models = await orderService.GetAllOrdersByUserId(ClaimsPrincipalExtentions.Id(this.User));
            return View(models);
        }
    }
}
