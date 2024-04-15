﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Extentions;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Models.Garment;
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

        public async Task<IActionResult> All(int currentPage)
        {
            var model = new AllAccessoryViewModel();
            if (service.GetAllAccessoryAsync().Result.Count > 0)
            {

                int totalRecords = service.GetAllAccessoryAsync().Result.Count;
                var pageSize = 3;
                var totalPages = (int)Math.Ceiling(totalRecords / (decimal)pageSize);

                model.CurrentPage = currentPage;
                model.PageSize = pageSize;
                model.TotalPages = totalPages;


                var accessories = service.GetAllAccessoryAsync().Result
                    .ToList();

                accessories = accessories.Skip((currentPage - 1) * (pageSize))
                    .Take(pageSize)
                    .ToList();
                model.Accessories = accessories;
                if (accessories.Count != null && accessories.Count > 0)
                {

                    return View(model);
                }
            }


            return RedirectToAction("Index", "Home");
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
