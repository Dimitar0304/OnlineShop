using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.Size;
using OnlineShop.Core.Models.Type;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Services.GarmentService
{
    /// <summary>
    /// Garment service
    /// </summary>
    public class GarmentService : IGarmentService
    {
        private readonly IRepository repository;
        public GarmentService(IRepository _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Garment add service method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddGarmentToDbAsync(GarmentViewModel model)
        {
            if (model != null)
            {
                var g = new Garment()
                {
                    Id = model.Id,
                    Model = model.Name,
                    TypeId = model.TypeId,
                    BrandId = model.BrandId,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    Color = model.Color,
                    IsActive = true

                };
                await repository.AddAsync(g);
                await repository.SaveChangesAsync();

            }

        }
        /// <summary>
        /// Garment remove method
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGarmentToDbAsync(int id)
        {
            var g = repository.GetByIdAsync<Garment>(id);
            if (g != null)
            {

                repository.Delete(g);
                repository.SaveChangesAsync();
            }

        }
        /// <summary>
        /// Method for returns all garments async
        /// </summary>
        /// <returns></returns>
        public async Task<List<GarmentViewModel>> GetAllGarmentsAsync()
        {
            return await repository
                .All<Garment>()
                .Where(g => g.IsActive == true)
                .Select(g => new GarmentViewModel()
                {
                    Id = g.Id,
                    Name = g.Model,
                    TypeId = g.TypeId,
                    BrandId = g.BrandId,
                    Price = g.Price,
                    Color = g.Color,
                    ImageUrl = g.ImageUrl,
                    BrandName = g.Brand.Name,
                    Brands = repository.All<Brand>().Select(b => new BrandViewModel()
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToList(),

                })
                .AsNoTracking()
                   .ToListAsync();


        }
        /// <summary>
        /// Method that returns me garmentViewModel by current id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<GarmentViewModel> GetByIdAsync(int id)
        {
            var g = await repository.All<Garment>().Select(g => new GarmentViewModel()
            {
                Id = id,
                Name = g.Model,
                TypeId = g.TypeId,
                BrandId = g.BrandId,
                Price = g.Price,
                Color = g.Color,
                BrandName = g.Brand.Name,

            }).Where(g => g.Id == id)
            .FirstAsync();
            return g;
        }
        /// <summary>
        /// Method that update exist garment model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task UpdateGarmentToDbAsync(GarmentViewModel model)
        {
            Garment g = await repository.GetByIdAsync<Garment>(model.Id);


            if (g != null)
            {
                g.Model = model.Name;
                g.BrandId = model.BrandId;
                g.Price = model.Price;
                g.Color = model.Color;
                g.TypeId = model.TypeId;
                


                await repository.UpdateAsync<Garment>(g);
                await repository.SaveChangesAsync();

            }
        }

        /// <summary>
        /// Method that returns possible brands
        /// </summary>
        /// <returns></returns>
        public async Task<List<BrandViewModel>> GetBrands()
        {
            return await repository.All<Brand>()
                .Select(b => new BrandViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Method that return possible Sizes when we add to cart
        /// </summary>
        /// <returns></returns>

        public async Task<List<SizeViewModel>> GetSizes()
        {


            return await repository.All<Size>()
                .Select(s => new SizeViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToListAsync();

        }

        /// <summary>
        /// Method for get all type and  choose from it
        /// </summary>
        /// <returns></returns>
        public async Task<List<TypeAllViewModel>> GetTypes()
        {
            return await repository.All<GarmentType>()
                .Select(t => new TypeAllViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        /// <summary>
        /// Method for add garment with current size to db
        /// </summary>
        /// <param name="sizeId"></param>
        /// <param name="garmentId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddGarmentWithSizeToDb(string SizeName, int garmentId)
        {

            var model = new GarmentSize()
            {
                GarmentId = garmentId,
                SizeId = repository.All<Size>().Where(s => s.Name == SizeName).First().Id
            };
            await repository.AddAsync(model);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Method for check is current adding garment exist in db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> IsGarmentExist(GarmentViewModel model)
        {
            var garments = await repository.All<Garment>()
                .Where(g => g.Model.ToLower() == model.Name.ToLower())
                .ToListAsync();
            if (garments.Count() >= 1 && garments != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method for gett SizeViewModels for given garment
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<SizeViewModel>> GetSizeViewModels(int modelId)
        {
            var availableSizes = repository.All<GarmentSize>()
                .Where(g => g.GarmentId == modelId)
                .Select(s => new SizeViewModel()
                {
                    Id = s.SizeId,
                    Name = s.Size.Name
                })
                .ToListAsync();
            return availableSizes;

        }

        public async Task SoftDelete(int id)
        {
            var entity = await repository.GetByIdAsync<Garment>(id);
            entity.IsActive = false;
            await repository.UpdateAsync<Garment>(entity);
            await repository.SaveChangesAsync();
        }
    }
}
