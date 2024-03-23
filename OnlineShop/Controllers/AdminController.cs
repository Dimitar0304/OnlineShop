using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (await userManager.IsInRoleAsync(user, roleName) == false)
                {

                    var role = await roleManager.FindByNameAsync(roleName);
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
