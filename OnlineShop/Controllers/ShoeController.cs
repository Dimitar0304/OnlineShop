using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Controllers
{
    
    /// <summary>
    /// Shoe contoller class
    /// </summary>
    public class ShoeController : BaseController
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
        public async Task<IActionResult> All(int currentPage)
        {
            //model for pass to view
            var model = new ShoeAllViewModel();

            //enities per page size
            int pageSize = 3;

            //get all enitites
            var models = await service.GetAllShoeAsync();

            //get total pages count 
            int totalPages = (int)Math.Ceiling(models.Count / (decimal)pageSize);

            //set currentPage index
            model.CurrentPage = currentPage;

            //set entities per page size
            model.PageSize = pageSize;

            //set totalpages
            model.TotalPages = totalPages;

            //get list of entities for currentPage
            model.Shoes = models.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            if (models.Count != null && models.Count > 0)
            {

                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Method for show details to current shoe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }
            var entity = await service.GetByIdAsync(id);
            var model = new ShoeDetailsViewModel()
            {
                Name = entity.Name,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Color = entity.Color,
                TypeName = service.GetTypes().FirstOrDefault(t => t.Id == entity.TypeId).Name,
                BrandName = entity.BrandName,
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
