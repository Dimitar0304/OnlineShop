using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class Accessory : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
