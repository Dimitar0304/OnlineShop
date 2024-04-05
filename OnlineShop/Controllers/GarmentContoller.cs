using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Garment;
using OnlineShop.Core.Models.Order;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Extentions;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using Syncfusion.EJ2.Linq;
using X.PagedList;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class GarmentController : Controller
    {
        private readonly IGarmentService service;
        private readonly IGarmentSizeService garmentSizeService;
        public GarmentController(IGarmentService _service, IGarmentSizeService _garmentSizeService)
        {
            service = _service;
            garmentSizeService = _garmentSizeService;
        }

        public async Task<IActionResult> All(int currentPage)
        {
            var model = new AllGarmentViewModel();
            if (service.GetAllGarmentsAsync().Result.Count > 0)
            {

                int totalRecords = service.GetAllGarmentsAsync().Result.Count;
                var pageSize = 3;
                var totalPages = (int)Math.Ceiling(totalRecords / (decimal)pageSize);

                model.CurrentPage = currentPage;
                model.PageSize = pageSize;
                model.TotalPages = totalPages;


                var garments = service.GetAllGarmentsAsync().Result
                    .ToList();

                garments = garments.Skip((currentPage - 1) * (pageSize))
                    .Take(pageSize)
                    .ToList();
                model.Garments = garments;
                if (garments.Count != null && garments.Count > 0)
                {

                    return View(model);
                }
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

        /// <summary>
        /// Action for add garment with chosen size to db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> PickSize(int id)
        {
            var model = new GarmentSizeViewModel();
            model.Sizes = await service.GetSizes();
            model.GarmentId = id;

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(OrderDetailModel model)
        {

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (id < 0 && service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            var entity = await service.GetByIdAsync(id);
            if (entity == null)
            {
                return RedirectToAction("All", "Garment");
            }
            var model = new GarmentDetailsViewModel()
            {
                Name = entity.Name,
                TypeName = service.GetTypes().Result.Where(t => t.Id == entity.TypeId).FirstOrDefault().Name,
                Price = entity.Price,
                BrandName = entity.BrandName,
                Color = entity.Color,
                AvailableSizes = await service.GetSizeViewModels(id)

            };
            if (information != model.GetInformation())
            {
                return BadRequest();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            GarmentViewModel model = await service.GetByIdAsync(id);
            //if (information != model.GetInformation())
            //{
            //    return BadRequest();
            //}
            model.Brands = await service.GetBrands();
            model.Types = await service.GetTypes();

            return View("Edit", model);
        }
        [HttpGet]
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
