using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Core.Models.Garment;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Extentions;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;
using Syncfusion.EJ2.Linq;
using X.PagedList;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class GarmentController : Controller
    {
        private readonly IGarmentService service;
        private readonly IGarmentSizeService garmentSizeService;
        public GarmentController(IGarmentService _service, IGarmentSizeService _garmentSizeService)
        {
            service = _service;
            garmentSizeService = _garmentSizeService;
        }

        public async Task<IActionResult> All(int? page)
        {

            var pageNumber = page ?? 1;

            var pageSize = 3;

            var models = service.GetAllGarmentsAsync().Result.ToList();

            int counterOfPages = models.Count % pageSize;

            List<IPagedList<GarmentViewModel>> pagedData=new List<IPagedList<GarmentViewModel>>();
            for (int i = 1; i <= counterOfPages; i++)
            {
                pagedData.Add(await service
                .GetAllGarmentsAsync().Result.Skip(pageNumber - 1 * pageSize).Take(pageSize)
                .ToPagedListAsync(pageNumber, pageSize)); 

            }

                
            if (pagedData.Count!=null&&pagedData.Count>0)
            {

                return View(pagedData);
    }
            return RedirectToAction("Index", "Home");

}
[HttpGet]
// [Authorize(Roles = "Admin")]
public async Task<IActionResult> Add()
{
    var model = new GarmentViewModel();
    model.Brands = await service.GetBrands();
    model.Types = await service.GetTypes();
    return View(model);
}
[HttpPost]
//[Authorize(Roles = "Admin")]
public async Task<IActionResult> Add(GarmentViewModel model)
{
    if (!ModelState.IsValid)
    {

        model.Brands = await service.GetBrands();
        model.Types = await service.GetTypes();
        return View(model);
    }
    if (await service.IsGarmentExist(model))
    {
        ModelState.AddModelError("Error", "");
        model.Brands = await service.GetBrands();
        model.Types = await service.GetTypes();
        return View(model);
    }

    else
    {
        //add garment to db
        await service.AddGarmentToDbAsync(model);

        //Get identifier of last added garment
        var lastAddedGarmentId = service.GetAllGarmentsAsync().Result.Last().Id;

        //Add garmentSize models with last added garment in db
        await garmentSizeService.AddGarmentWithSizes(lastAddedGarmentId);
        //return view
        return RedirectToAction("Index", "Home");
    }
}

/// <summary>
/// Action for add garment with chosen size to db
/// </summary>
/// <param name="id"></param>
/// <returns></returns>

[HttpPost]
public async Task<IActionResult> AddToCart(int id)
{
    var model = new GarmentSizeViewModel();
    model.Sizes = await service.GetSizes();
    model.GarmentId = id;

    return View(model);

}
[HttpGet]
public async Task<IActionResult> AddToCart(GarmentSizeViewModel model)
{
    if (model != null)
    {
        await service.AddGarmentWithSizeToDb(model.SizeName, model.GarmentId);
        return RedirectToAction("Cart", "Home");
    }

    model = new GarmentSizeViewModel();
    model.Sizes = await service.GetSizes();
    return View(model);
}

[HttpPost]
public async Task<IActionResult> Details(int id)
{
    if (id < 0)
    {
        return RedirectToAction("All", "Garment");
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
        Brand = entity.BrandName,
        Color = entity.Color,
        AvailableSizes = await service.GetSizeViewModels(id)

    };
    return View(model);
}
    }
}
