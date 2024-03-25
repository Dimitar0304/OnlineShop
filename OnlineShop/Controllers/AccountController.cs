﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.User;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signManager;
        private readonly UserManager<User> userManager;
        private readonly ILogger logger;
        public AccountController(SignInManager<User> _signManager,
            UserManager<User> _userManager,
            ILogger _logger)
        {
            signManager = _signManager;
            userManager = _userManager;
            logger = _logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData[returnUrl] = returnUrl;

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model, string returnUrl = null)
        {
            ViewBag[returnUrl] = returnUrl;

            if (ModelState.IsValid)
            {
                User user = userManager.Users.FirstOrDefault(u => u.UserName == model.UserName);
                if (user != null)
                {

                    var result = await signManager.PasswordSignInAsync(user, model.Password,true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        this.logger.LogInformation("User logged in.");
                        return RedirectToLocal(returnUrl);
                    }

                    if (result.IsLockedOut)
                    {
                        this.logger.LogWarning("User account locked out.");
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
        public IActionResult Lockout()
        {
            return View();
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
    }
}
