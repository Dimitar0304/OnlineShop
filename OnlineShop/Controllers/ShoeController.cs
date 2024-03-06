using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Controllers
{
    [Authorize]
    /// <summary>
    /// Shoe contoller class
    /// </summary>
    public class ShoeController : Controller
    {
        /// <summary>
        /// Inject service using dependency injection
        /// </summary>
        private readonly IShoeService service;
        public ShoeController(IShoeService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Action for Display all shoes
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            var models =await service.GetAllShoeAsync();
            if (models == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(models);
        }

        /// <summary>
        /// Action for add shoe to db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model =  new ShoeAddViewModel();
            model.Brands = await service.GetBrands();
            model.Types = await service.GetTypes();
            return  View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ShoeAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = new ShoeAddViewModel();
                model.Brands = await service.GetBrands();
                model.Types = await service.GetTypes();
                return View(model);
            }
            if (service.ShoeIsExistInDb(model)==true)
            {
                ModelState.AddModelError("Error", "");
            }
            await service.AddShoeToDbAsync(model);
            return RedirectToAction("All");   
        }
    }
}
