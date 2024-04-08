using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class MainAdminController:BaseAdminController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
