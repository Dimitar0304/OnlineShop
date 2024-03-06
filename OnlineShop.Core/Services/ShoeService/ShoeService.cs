using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Models.Type;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;
using OnlineShop.Models.Size;
using System.Reflection.PortableExecutable;

namespace OnlineShop.Core.Services.ShoeService
{
    /// <summary>
    /// Shoe service
    /// </summary>
    public class ShoeService : IShoeService
    {

        /// <summary>
        /// Inject repository in service using dependency injection
        /// </summary>
        private readonly IRepository repository;
        public ShoeService(IRepository _repository)
        {
            repository = _repository;
        }
      
        /// <summary>
        /// Method for add shoe to db context
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddShoeToDbAsync(ShoeAddViewModel model)
        {
            var shoe = new Shoe()
            {
                Id = model.Id,
                Model = model.Model,
                Price = model.Price,
                BrandId = model.BrandId,
                TypeId = model.TypeId,
                ImageUrl = model.ImageUrl,
                Color = model.Color,
            };
           await repository.AddAsync<Shoe>(shoe);
        }

        /// <summary>
        /// Method for delete shoe in db context
        /// </summary>
        /// <param name="id"></param>
        public void DeleteShoeToDbAsync(int id)
        {
            var shoe = repository.GetByIdAsync<Shoe>(id);

            repository.Delete(shoe);
        }

        /// <summary>
        /// Method for get all shoes 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ShoeAddViewModel>> GetAllShoeAsync()
        {
            return await repository.All<Shoe>().Select(s => new ShoeAddViewModel()
            {
                Id = s.Id,
                Model = s.Model,
                Price = s.Price,
                Color = s.Color,
                BrandId = s.BrandId,
                TypeId = s.TypeId,
                ImageUrl = s.ImageUrl,
            })
                 .ToListAsync();

        }

        /// <summary>
        /// Method for get all brands
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
        /// Method that get shoe by id from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ShoeAddViewModel> GetByIdAsync(int id)
        {
            var model= await repository.GetByIdAsync<Shoe>(id);
            return new ShoeAddViewModel()
            {
                Id = model.Id,
                Model = model.Model,
                Price = model.Price,
                Color = model.Color,
                BrandId = model.BrandId,
                TypeId = model.TypeId,
                ImageUrl = model.ImageUrl,
            };
        }

        /// <summary>
        /// Method for get sizes from db
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
        /// Method for get types from db
        /// </summary>
        /// <returns></returns>
        public async Task<List<TypeAllViewModel>> GetTypes()
        {
            return await repository.All<ShoeType>()
              .Select(t => new TypeAllViewModel()
              {
                  Id = t.Id,
                  Name = t.Name,
              })
              .ToListAsync();
        }

        /// <summary>
        /// Method for update current entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateShoeToDbAsync(ShoeAddViewModel model)
        {
            var shoe = await repository.GetByIdAsync<Shoe>(model.Id);

            if (shoe!=null)
            {

            shoe.Price = model.Price;
            shoe.Color = model.Color;
            shoe.Model = model.Model;
            shoe.BrandId = model.BrandId;
            shoe.TypeId = model.TypeId;
            shoe.ImageUrl = model.ImageUrl;

            await repository.UpdateAsync(shoe);
            await repository.SaveChangesAsync();

            }
            
        }

        /// <summary>
        /// Method for entity check
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ShoeIsExistInDb(ShoeAddViewModel model)
        {
            var entity =  repository.AllReadOnly<Shoe>()
                .Where(s => s.Model == model.Model && s.Color == model.Color);
            if (entity!=null)
            {
                return true;
            }
            return false;
        }

    }
}
