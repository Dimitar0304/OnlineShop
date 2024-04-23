using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(DataConstants.AdminConstants.AdminRoleName)]
    [Authorize(Roles =DataConstants.AdminConstants.AreaName)]
    [AutoValidateAntiforgeryToken]
    public abstract  class BaseAdminController:Controller
    {
    }
}
