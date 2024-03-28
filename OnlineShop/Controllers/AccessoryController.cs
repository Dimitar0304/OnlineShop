using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
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
                var models = await service.GetAllAccessoryAsync();
                return RedirectToAction("All",models);
            }
            
        }

        /// <summary>
        /// Method for get all accessories
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            var models = await service.GetAllAccessoryAsync();

            return View(models);
        }

        public async Task<IActionResult> Details(int id, string information)
        {
            if (await service.GetByIdAsync(id)==null)
            {
                return BadRequest();
            }
            var entity = await service.GetByIdAsync(id);
            var model = new AccessoryDetailsViewModel()
            {
                Name = entity.Name,
                Price = entity.Price,
                BrandName= service.GetBrands().Result.FirstOrDefault(b=>b.Id==entity.BrandId).Name,
                ImageUrl = entity.ImageUrl
            };
            if (information!=model.GetInformation())
            {
                return BadRequest();
            }
            return View(model);
        }
    }
}
