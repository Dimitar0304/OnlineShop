using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BaseController:Controller
    {
    }
}
