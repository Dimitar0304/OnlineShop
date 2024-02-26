using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Services
{
    /// <summary>
    /// Garment service
    /// </summary>
    public class GarmentService : IGarmentService
    {
        /// <summary>
        /// Database field
        /// </summary>
        private readonly ApplicationDbContext data;
        /// <summary>
        /// Dependency injection constructor
        /// </summary>
        /// <param name="_context"></param>
        public GarmentService(ApplicationDbContext _context)
        {
            data = _context;
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
                    Model = model.Model,
                    TypeId = model.TypeId,
                    BrandId = model.BrandId,
                    Price = model.Price,
                    Color = model.Color,

                };
                await data.Garments.AddAsync(g);
                await data.SaveChangesAsync();

            }

        }
        /// <summary>
        /// Garment remove method
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGarmentToDbAsync(int id)
        {
            var g = data.Garments.FirstOrDefault(g => g.Id == id);
            if (g != null)
            {
                
                data.Garments.Remove(g);
                data.SaveChanges();
            }
            
        }
        /// <summary>
        /// Method for returns all garments async
        /// </summary>
        /// <returns></returns>
        public async Task<List<GarmentViewModel>> GetAllGarmentsAsync()
        {
            return await data.Garments
                .Select(g=>new GarmentViewModel()
                {
                    Id = g.Id,
                    Model = g.Model,
                    TypeId = g.TypeId,
                    BrandId = g.BrandId,
                    Price = g.Price,
                    Color = g.Color
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
            var g = await data.Garments.Select(g => new GarmentViewModel()
            {
                Id = id,
                Model = g.Model,
                TypeId = g.TypeId,
                BrandId = g.BrandId,
                Price = g.Price,
                Color = g.Color

            }).Where(g=>g.Id == id)
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
            Garment g = await data.Garments.FirstOrDefaultAsync(g=>g.Id==model.Id);


           if (g != null)
            {
                g.Model = model.Model;
                g.BrandId = model.BrandId;
                g.Price = model.Price;
                g.Color = model.Color;
                g.TypeId = model.TypeId;


                data.Garments.Update(g);
                await data.SaveChangesAsync();

            }
        }

        /// <summary>
        /// Method that returns possible brands
        /// </summary>
        /// <returns></returns>
        public async Task<List<BrandViewModel>> GetBrands()
        {
            return await data.Brands
                .Select(b => new BrandViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
