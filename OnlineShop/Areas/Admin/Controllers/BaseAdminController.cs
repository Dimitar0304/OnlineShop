using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(DataConstants.RoleConstants.AdminRoleName)]
    [Authorize(Roles ="Admin")]
    public  class BaseAdminController:Controller
    {
    }
}
