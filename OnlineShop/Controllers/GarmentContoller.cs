using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class GarmentContoller : Controller
    {
        private readonly IGarmentService service;
        public GarmentContoller(IGarmentService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> All()
        {
            var models = await service.GetAllGarmentsAsync();
            return View(models);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            var model = new GarmentViewModel();
            model.Brands = await service.GetBrands();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(GarmentViewModel model)
        {
            if (ModelState.IsValid)
            {

                await service.AddGarmentToDbAsync(model);
                return RedirectToAction("Index", "Home");
            }
            model.Brands = await service.GetBrands();
            return View(model);
        }

    }
}
