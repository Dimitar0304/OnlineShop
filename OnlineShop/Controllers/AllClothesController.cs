using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.AllClothes;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Controllers
{
    
    public class AllClothesController : BaseController
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
        public IActionResult ShowSearchedItems(string? term, int currentPage)
        {
            var model = new AllClothesViewModel();
            
            if (string.IsNullOrEmpty(term))
            {
                return RedirectToAction("Index", "Home");
            }
            term = term.ToLower();
            model.Term = term;


            //make collection of clothesViewModels
            var models = new List<ClothesViewModel>();

            //Select all garments wich contains current string
            var garments = garmentService.GetAllGarmentsAsync().Result
                .Where(g => g.Name.ToLower().Contains(term));

            //Select all shoes wich contains current string
            var shoes = shoeService.GetAllShoeAsync().Result
               .Where(g => g.Name.ToLower().Contains(term));

            //Select all accssesories wich contains current string
            var accessories = accessoryService.GetAllAccessoryAsync().Result
                .Where(a => a.Name.ToLower().Contains(term));

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
            if (models.Count <= 0)
            {

                return RedirectToAction("Index", "Home");
            }
            model.CurrentPage = currentPage;
            model.PageSize = 5;
            model.TotalPages = (int)Math.Ceiling(models.Count / (decimal)model.PageSize);
            //return view
            model.Clothes = models.Skip((currentPage - 1) * model.PageSize)
                .Take(model.PageSize)
                .ToList();

            return View(model);


        }

       
    }
}
