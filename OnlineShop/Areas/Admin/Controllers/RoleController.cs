using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class RoleController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }


        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {


            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (await userManager.IsInRoleAsync(user, roleName) == false)
                {

                    var roles = roleManager.Roles.ToList();
                    var role = roles.FirstOrDefault(r => r.Name == roleName);
                    if (role != null)
                    {
                        await userManager.AddToRoleAsync(user, roleName);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
