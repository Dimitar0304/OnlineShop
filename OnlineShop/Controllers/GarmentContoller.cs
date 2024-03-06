using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Extentions;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class GarmentController : Controller
    {
        private readonly IGarmentService service;
        public GarmentController(IGarmentService _service)
        {
            service = _service;
            
        }

        public async Task<IActionResult> All()
        {
            var model = new AllGarmentViewModel();
            model.Garments = await service.GetAllGarmentsAsync();
            if (model.Garments.Count > 0 && model.Garments != null)
            {

                return View(model);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            var model = new GarmentViewModel();
            model.Brands = await service.GetBrands();
            model.Types = await service.GetTypes();
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

        [HttpGet]
        public async Task<IActionResult> AddToCart(int id)
        {
            var model = new GarmentSizeViewModel();
            model.Sizes = await service.GetSizes();
            model.GarmentId = id;

            return View(model);
            
        }
        //[HttpPost]
        //public async Task<IActionResult> AddToCart(GarmentSizeViewModel model)
        //{

        //}
        public void getUserid()
        {
            var id = ClaimsPrincipalExtentions.Id(this.User);
        }

    }
}
