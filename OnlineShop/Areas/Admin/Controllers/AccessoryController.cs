using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Models.Garment;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccessoryController:BaseAdminController
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
                return RedirectToAction("All", models);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.SoftDelete(id);
            var models = await service.GetAllAccessoryAsync();
            return RedirectToAction("All", models);
        }

        public async Task<IActionResult> DeleteFromDb(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.DeleteAccessoryToDbAsync(id);
            var models = await service.GetAllAccessoryAsync();
            return RedirectToAction("All", models);
        }

        public async Task<IActionResult> Edit(int id, string information)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            AccessoryAddViewModel model = await service.GetByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }
            model.Brands = await service.GetBrands();
           

            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AccessoryAddViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                model.Brands = await service.GetBrands();
                
                return View(model);
            }
            await service.UpdateAccessoryToDbAsync(model);
            return RedirectToAction("All", "Garment");
        }
    }
}
