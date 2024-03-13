using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Controllers
{
    [Authorize]
    /// <summary>
    /// Accessory controller
    /// </summary>
    public class AccessoryController : Controller
    {
        /// <summary>
        /// Add service to controller injecting it with dependency injection
        /// </summary>
        private readonly IAccessoryService service;
        public AccessoryController(IAccessoryService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Method for add accessory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AccessoryAddViewModel();

            model.Brands = await service.GetBrands();

            return View(model);
        }

        /// <summary>
        /// Post add method for add accessory in db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AccessoryAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = new AccessoryAddViewModel();

                model.Brands = await service.GetBrands();
                return View(model);
            }
            if (service.AccessoryIsExistInDb(model))
            {

                ModelState.AddModelError("Error", "");
            }
            else
            {

            }
            return View();
        }
    }
}
