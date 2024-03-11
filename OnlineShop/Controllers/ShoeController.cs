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
        private readonly IShoeSizeService shoeSizeService;
        public ShoeController(IShoeService _service, IShoeSizeService _shoeSizeService)
        {
            service = _service;
            shoeSizeService = _shoeSizeService;
        }

        /// <summary>
        /// Action for Display all shoes
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            var models = await service.GetAllShoeAsync();
            if (models == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new ShoeAllViewModel();
            model.Shoes = models;
            
            return View(model);
        }

        /// <summary>
        /// Action for add shoe to db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ShoeAddViewModel();
            model.Brands = service.GetBrands();
            model.Types = service.GetTypes();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ShoeAddViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model = new ShoeAddViewModel();
                model.Brands = service.GetBrands();
                model.Types = service.GetTypes();
                return View(model);
            }
            if (service.ShoeIsExistInDb(model))
            {
                ModelState.AddModelError("Error", "");
            }
            else
            {
                //add shoe to db
                await service.AddShoeToDbAsync(model);

                //get last shoe added identitfier
                var shoeId = service.GetAllShoeAsync().Result.Last().Id;

                //add for each  size shoesize model in db
                await shoeSizeService.AddShoeSizeModels(shoeId); 

                //return to all shoes view
                return RedirectToAction("All");
            }
            return RedirectToAction("All");
        }
    }
}
