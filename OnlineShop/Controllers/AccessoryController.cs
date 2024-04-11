using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;
using SendGrid.Helpers.Errors.Model;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;

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
        [HandleError]
        public async Task<IActionResult> Details(int id, string information)
        {
            try
            {


                if (await service.GetByIdAsync(id) == null)
                {
                    throw new BadRequestException("");
                }
                var entity = await service.GetByIdAsync(id);
                var model = new AccessoryDetailsViewModel()
                {
                    Name = entity.Name,
                    Price = entity.Price,
                    BrandName = service.GetBrands().Result.FirstOrDefault(b => b.Id == entity.BrandId).Name,
                    ImageUrl = entity.ImageUrl
                };
                if (information != model.GetInformation())
                {
                    throw new BadRequestException("");
                }

                return View(model);
            }
            catch (BadRequestException ex)
            {
                
                return RedirectToAction("BadRequest", "Error");
            }
            catch(NotFoundException nfE)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }
    }
}
