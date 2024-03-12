using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class AllClothesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
