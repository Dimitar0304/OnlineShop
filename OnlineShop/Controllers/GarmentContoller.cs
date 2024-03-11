﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Extentions;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using X.PagedList;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class GarmentController : Controller
    {
        private readonly IGarmentService service;
        private readonly IGarmentSizeService garmentSizeService;
        public GarmentController(IGarmentService _service,IGarmentSizeService _garmentSizeService)
        {
            service = _service;
            garmentSizeService = _garmentSizeService;
        }

        public async Task<IActionResult> All(int? page)
        {

            var pageNumber = page?? 1;

            var pageSize = 4;


            var model = new AllGarmentViewModel();
            model.Garments = await service.GetAllGarmentsAsync();

            var pagedData = model.Garments.ToPagedList<GarmentViewModel>(pageNumber,pageSize);

            if (model.Garments.Count > 0 && model.Garments != null)
            {

                return View(pagedData);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            var model = new GarmentViewModel();
            model.Brands = await service.GetBrands();
            model.Types = await service.GetTypes();
            return View(model);
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(GarmentViewModel model)
        {
            
            if (ModelState.IsValid)
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
            model.Brands = await service.GetBrands();
            model.Types = await service.GetTypes();
            return View(model);
        }

        /// <summary>
        /// Action for add garment with chosen size to db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var model = new GarmentSizeViewModel();
            model.Sizes = await service.GetSizes();
            model.GarmentId = id;

            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> AddToCart(GarmentSizeViewModel model)
        {
            if (model != null)
            {
                await service.AddGarmentWithSizeToDb(model.SizeName, model.GarmentId);
                return RedirectToAction("Cart", "Home");
            }

            model = new GarmentSizeViewModel();
            model.Sizes = await service.GetSizes();
            return View(model);
        }

        

    }
}
