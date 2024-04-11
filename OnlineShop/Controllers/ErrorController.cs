using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
                    break;

                case 500:
                        ViewBag.ErrorMessage = "Bad Request";
                    break;
                
                default:
                    ViewBag.ErrorMessage = "Oops! Something went wrong.";
                    break;
            }
            return View("Error");
        }
    }
}
