using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class GarmentContoller : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
