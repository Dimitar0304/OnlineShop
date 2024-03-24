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
        private readonly IAccessoryService accessoryService;
        public AllClothesController(IGarmentService _garmentService, IShoeService _shoeService
            , IAccessoryService _accessoryService)
        {
            garmentService = _garmentService;
            shoeService = _shoeService;
            accessoryService = _accessoryService;

        }
        public IActionResult ShowSearchedItems(string? term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return RedirectToAction("Index","Home");   
            }
            term = term.ToLower();


            //make collection of clothesViewModels
            var models = new List<ClothesViewModel>();

            //Select all garments wich contains current string
            var garments = garmentService.GetAllGarmentsAsync().Result
                .Where(g => g.Name.ToLower().StartsWith(term));

            //Select all shoes wich contains current string
            var shoes = shoeService.GetAllShoeAsync().Result
               .Where(g => g.Name.ToLower().StartsWith(term));

            //Select all accssesories wich contains current string
            var accessories = accessoryService.GetAllAccessoryAsync().Result
                .Where(a => a.Name.ToLower().StartsWith(term));

            //foreach loop to add garments in allClothes list
            foreach (var g in garments)
            {
                models.Add(new ClothesViewModel()
                {
                    ClothesType = "Garment",
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
                    ClothesType = "Shoe",
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ImageUrl,
                    Price = s.Price,
                });
            }

            //foreach loop to add accessories in allClothes list
            foreach (var a in accessories)
            {
                models.Add(new ClothesViewModel()
                {
                    ClothesType = "Accessory",
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    Name = a.Name,
                    Price = a.Price,
                });
            }
            //return view
            if (models.Count > 0)
            {
                return View(models);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
