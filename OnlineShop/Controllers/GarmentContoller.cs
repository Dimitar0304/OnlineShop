using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Garment;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using Syncfusion.EJ2.Linq;


namespace OnlineShop.Controllers
{

    public class GarmentController : BaseController
    {
        private readonly IGarmentService service;
        
        private readonly IHttpContextAccessor context;
        public GarmentController(IGarmentService _service, IHttpContextAccessor context)
        {
            service = _service;
            
            this.context = context;
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
        /// Method for show details to current garment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return RedirectToAction("Error","500");
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
                return RedirectToAction("Error", "500");
            }
            return View(model);
        }

      
    }
}
