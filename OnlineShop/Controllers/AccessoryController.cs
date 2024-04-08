using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;

namespace OnlineShop.Controllers
{
    /// <summary>
    /// Accessory controller
    /// </summary>
    public class AccessoryController : BaseController
    {
        /// <summary>
        /// Add service to controller injecting it with dependency injection
        /// </summary>
        private readonly IAccessoryService service;
        public AccessoryController(IAccessoryService _service)
        {
            service = _service;
        }
        /// <summary>
        /// Method for get all accessories
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            var models = await service.GetAllAccessoryAsync();

            return View(models);
        }

        /// <summary>
        /// Method for get details to current accessory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await service.GetByIdAsync(id)==null)
            {
                return BadRequest();
            }
            var entity = await service.GetByIdAsync(id);
            var model = new AccessoryDetailsViewModel()
            {
                Name = entity.Name,
                Price = entity.Price,
                BrandName= service.GetBrands().Result.FirstOrDefault(b=>b.Id==entity.BrandId).Name,
                ImageUrl = entity.ImageUrl
            };
            if (information!=model.GetInformation())
            {
                return BadRequest();
            }
            return View(model);
        }
    }
}
