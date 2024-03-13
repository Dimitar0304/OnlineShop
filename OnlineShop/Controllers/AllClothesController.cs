using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Controllers
{
    public class AllClothesController : Controller
    {
        private readonly IGarmentService garmentService;
        private readonly IShoeService shoeService;
        public AllClothesController(IGarmentService _garmentService,IShoeService _shoeService)
        {
            garmentService = _garmentService;
            shoeService = _shoeService;
        }
        public IActionResult SearchAllByName(string productName)
        {
            var garments = garmentService.GetAllGarmentsAsync().Result
                .Where(g=>g.Name.Contains(productName.ToLower()));

            var shoes = shoeService.GetAllShoeAsync().Result
               .Where(g => g.Name.Contains(productName.ToLower()));


        }
    }
}
