using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models.AllClothes;

namespace OnlineShop.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandService brandService;
        public BrandController(IBrandService _brandService)
        {
            brandService = _brandService;
        }

        public async Task<IActionResult> AllBrands(int currentPage)
        {
            var model = new AllBrandsViewModel();

            int totalRecords = brandService.GetAllBrands().Result.Count;
            var pageSize = 3;
            var totalPages = (int)Math.Ceiling(totalRecords / (decimal)pageSize);


            model.CurrentPage = currentPage;
            model.PageSize = pageSize;
            model.TotalPages = totalPages;


            var models = brandService.GetAllBrands().Result
                .ToList();

            models = models.Skip((currentPage - 1) * (pageSize))
                .Take(pageSize)
                .ToList();
            model.Brands = models;
            if (models.Count > 0)
            {

                return View(model);
            }
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        
        public async Task<IActionResult> GetClothesForBrand(int brandId)
        {
            var models = await brandService.GetClothesForCurrentBrand(brandId);

            return View(models);
        }
    }
}
