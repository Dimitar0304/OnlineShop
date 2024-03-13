using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.AllClothes;
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
        public IActionResult ShowSearchedItems(string productName)
        {
            //make collection of clothesViewModels
            var models = new List<ClothesViewModel>();

            //Select all garments wich contains current string
            var garments = garmentService.GetAllGarmentsAsync().Result
                .Where(g=>g.Name.Contains(productName.ToLower()));

            //Select all shoes wich contains current string
            var shoes = shoeService.GetAllShoeAsync().Result
               .Where(g => g.Name.Contains(productName.ToLower()));

            //Select all accssesories wich contains current string

            //foreach loop to add garments in allClothes list
            foreach (var g in garments)
            {
                models.Add(new ClothesViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    Price = g.Price,
                });
            }

            //foreach loop to add shoes in allClothes list
            foreach (var s in shoes)
            {
                models.Add(new ClothesViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ImageUrl,
                    Price = s.Price,
                });
            }

            //foreach loop to add accessories in allClothes list

            //return view
            return View(models);
        }
    }
}
