using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.Account;
using OnlineShop.Core.Models.User;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signManager;
        private readonly UserManager<User> userManager;
    
        public AccountController(SignInManager<User> _signManager,
            UserManager<User> _userManager
         )
        {
            signManager = _signManager;
            userManager = _userManager;
           
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model, string? returnUrl = null)
        {
            //ViewBag["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                User user = userManager.Users.FirstOrDefault(u => u.UserName == model.UserName);
                if (user != null)
                {

                    var result = await signManager.PasswordSignInAsync(user, model.Password,true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                       
                        return RedirectToLocal(returnUrl);
                    }

                    if (result.IsLockedOut)
                    {
                       
                        return RedirectToAction(nameof(Lockout));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterUser(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterUserFormModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegistrationDate = DateTime.UtcNow.ToLocalTime(),
                    PhoneNumber = model.PhoneNumber,
                };

                var result = await this.userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                   

                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);

                    await this.signManager.SignInAsync(user, isPersistent: false);
                    
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }
        


        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await this.signManager.SignOutAsync();
            
            return RedirectToAction("Index", "Home");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
