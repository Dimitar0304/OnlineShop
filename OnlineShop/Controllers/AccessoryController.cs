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
                model.Brands = await service.GetBrands();
                return View(model);
            }
            else
            {
                await service.AddAccessoryToDbAsync(model);
                return View("All");
            }

        }

        /// <summary>
        /// Method for get all accessories
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All(int currentPage)
        {
            var model = new AccessoryAllViewModel();

            var pageSize = 3;

            var models = await service.GetAllAccessoryAsync();

            var totalPages = (int)Math.Ceiling(models.Count / (decimal)pageSize);

            model.CurrentPage = currentPage;
            model.PageSize = pageSize;
            model.TotalPages = totalPages;
            model.Accessories = models.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            if (model.Accessories != null&&model.Accessories.Count>0)
            {

                return View(model);
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
