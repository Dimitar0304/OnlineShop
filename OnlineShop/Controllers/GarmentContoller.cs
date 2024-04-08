using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Garment;
using OnlineShop.Core.Models.Order;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Extentions;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using Syncfusion.EJ2.Linq;
using X.PagedList;

namespace OnlineShop.Controllers
{
    
    public class GarmentController : BaseController
    {
        private readonly IGarmentService service;
        private readonly IGarmentSizeService garmentSizeService;
        public GarmentController(IGarmentService _service, IGarmentSizeService _garmentSizeService)
        {
            service = _service;
            garmentSizeService = _garmentSizeService;
        }

        /// <summary>
        /// Method for get all garments
        /// </summary>
        /// <param name="currentPage"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Method for pick size to current garment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PickSize(int id)
        {
            var model = new GarmentSizeViewModel();
            model.Sizes = await service.GetSizes();
            model.GarmentId = id;

            return View(model);

        }

        /// <summary>
        /// Method for add current garmentSize model to user cart
        /// </summary>
        /// <param name="sizeId"></param>
        /// <param name="garmentId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToCart(int sizeId, int garmentId)
        {
            if (sizeId == null || garmentId == null)
            {

                return RedirectToAction("Index", "Home");
            }
           var model = await garmentSizeService.AddGarmentToCart(sizeId, garmentId);

           var viewModel = new GarmentSizeViewModel()
           {
               GarmentId = model.GarmentId,
               SizeName = model.Size.Name
           };

            var notFinalizedOrder = new OrderDetailModel()
            {
                UserId = ClaimsPrincipalExtentions.Id(this.User),
                UserName = User.Identity.Name,
                
                Garments = new List<GarmentSizeViewModel>()
               {
                   viewModel
               }
           };
            return RedirectToAction("Cart", "Order",notFinalizedOrder);
        }


        /// <summary>
        /// Method for show details to current garment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns></returns>
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

      
    }
}
