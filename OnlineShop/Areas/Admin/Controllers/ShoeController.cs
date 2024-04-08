﻿using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction("All");
            }
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.SoftDelete(id);
            var models = await service.GetAllShoeAsync();
            return RedirectToAction("All", models);
        }

        public async Task<IActionResult> DeleteFromDb(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            await service.DeleteShoeToDbAsync(id);
            var models = await service.GetAllShoeAsync();
            return RedirectToAction("All", models);
        }
    }
}