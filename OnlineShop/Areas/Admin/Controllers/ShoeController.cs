using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ShoeController : BaseAdminController
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
                return RedirectToAction("All","Shoe", new { area = "" });
            }
            return RedirectToAction("All","Shoe", new { area = "" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.SoftDelete(id);
            
            return RedirectToAction("DashBoard", "MainAdmin", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteFromDb(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.DeleteShoeToDbAsync(id);
            
            return RedirectToAction("DashBoard", "MainAdmin", new { area = "Admin" });
        }

        public async Task<IActionResult> Edit(int id, string information)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            var model = await service.GetByIdAsync(id);
            if (information != model.GetInformation())
            {
                return BadRequest();
            }
            model.Brands = service.GetBrands();
            model.Types = service.GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShoeAddViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                model.Brands = service.GetBrands();
                model.Types = service.GetTypes();

                return View(model);
            }
            await service.UpdateShoeToDbAsync(model);
            return RedirectToAction("All", "Shoe", new {area=""});
        }
    }
}
