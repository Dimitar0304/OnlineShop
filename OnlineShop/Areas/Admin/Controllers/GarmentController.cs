using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class GarmentController:BaseAdminController
    {
        private readonly IGarmentService service;
        private readonly IGarmentSizeService garmentSizeService;
        public GarmentController(IGarmentService _service, IGarmentSizeService _garmentSizeService)
        {
            service = _service;
            garmentSizeService = _garmentSizeService;
        }
        public async Task<IActionResult> Add()
        {
            var model = new GarmentViewModel();
            model.Brands = await service.GetBrands();
            model.Types = await service.GetTypes();
            return View(model);
        }
        [HttpPost]
       
        public async Task<IActionResult> Add(GarmentViewModel model)
        {
            if (!ModelState.IsValid)
            {

                model.Brands = await service.GetBrands();
                model.Types = await service.GetTypes();
                return View(model);
            }
            if (await service.IsGarmentExist(model))
            {
                ModelState.AddModelError("Error", "");
                model.Brands = await service.GetBrands();
                model.Types = await service.GetTypes();
                return View(model);
            }

            else
            {
                //add garment to db
                await service.AddGarmentToDbAsync(model);

                //Get identifier of last added garment
                var lastAddedGarmentId = service.GetAllGarmentsAsync().Result.Last().Id;

                //Add garmentSize models with last added garment in db
                await garmentSizeService.AddGarmentWithSizes(lastAddedGarmentId);
                //return view
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id,string information)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            GarmentViewModel model = await service.GetByIdAsync(id);
            
            if (information != model.GetInformation())
            {
                return BadRequest();
            }
            model.Brands = await service.GetBrands();
            model.Types = await service.GetTypes();

            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GarmentViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                model.Brands = await service.GetBrands();
                model.Types = await service.GetTypes();
                return View(model);
            }
            await service.UpdateGarmentToDbAsync(model);
            return RedirectToAction("All", "Garment");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.SoftDelete(id);
            var models = await service.GetAllGarmentsAsync();
            return RedirectToAction("All", models);
        }
        public async Task<IActionResult> DeleteFromDb(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.DeleteGarmentToDbAsync(id);
            var models = await service.GetAllGarmentsAsync();
            return RedirectToAction("All", models);
        }

    }
}
