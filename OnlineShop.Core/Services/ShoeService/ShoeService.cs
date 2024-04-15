using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Models.Size;
using OnlineShop.Core.Models.Type;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;

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
                Model = model.Name,
                Price = model.Price,
                BrandId = model.BrandId,
                TypeId = model.TypeId,
                ImageUrl = model.ImageUrl,
                Color = model.Color,
                IsActive = true
            };
            await repository.AddAsync<Shoe>(shoe);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Method for delete shoe in db context
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteShoeToDbAsync(int id)
        {
            var shoe = await repository.GetByIdAsync<Shoe>(id);
            if (shoe != null)
            {

                await repository.Delete(shoe);
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Method for get all shoes 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ShoeAddViewModel>> GetAllShoeAsync()
        {
            return await repository.All<Shoe>()
                .Where(s => s.IsActive == true)
                .Select(s => new ShoeAddViewModel()
                {
                    Id = s.Id,
                    Name = s.Model,
                    Price = s.Price,
                    Color = s.Color,
                    BrandId = s.BrandId,
                    TypeId = s.TypeId,
                    ImageUrl = s.ImageUrl,
                    BrandName = s.Brand.Name
                })
                 .ToListAsync();

        }

        /// <summary>
        /// Method for get all brands
        /// </summary>
        /// <returns></returns>
        public List<BrandViewModel> GetBrands()
        {

            return repository.All<Brand>()
                .Select(b => new BrandViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .AsNoTracking()
                .ToList();
        }

        /// <summary>
        /// Method that get shoe by id from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ShoeAddViewModel> GetByIdAsync(int id)
        {
            var allShoes = await repository.All<Shoe>().ToListAsync();
            var s = allShoes
                
                .Where(s=>s.Id==id)
                
                .Select(s => new ShoeAddViewModel()
                {
                    Id = id,
                    BrandName = GetBrands().FirstOrDefault(b=>b.Id==s.BrandId).Name,
                    ImageUrl = s.ImageUrl,
                    Color = s.Color,
                    Name = s.Model,
                    Price = s.Price,
                    BrandId = s.BrandId

                }).First()
                ;
                
            return s;
        }

        /// <summary>
        /// Method for get sizes from db
        /// </summary>
        /// <returns></returns>
        public List<SizeViewModel> GetSizes()
        {
            return repository.All<Size>()
              .Select(s => new SizeViewModel()
              {
                  Id = s.Id,
                  Name = s.Name,
              })
              .ToList();
        }

        /// <summary>
        /// Method for get types from db
        /// </summary>
        /// <returns></returns>
        public List<TypeAllViewModel> GetTypes()
        {
            return repository.All<ShoeType>()
              .Select(t => new TypeAllViewModel()
              {
                  Id = t.Id,
                  Name = t.Name,
              })
              .ToList();
        }

        /// <summary>
        /// Method for update current entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateShoeToDbAsync(ShoeAddViewModel model)
        {
            var shoe = await repository.GetByIdAsync<Shoe>(model.Id);

            if (shoe != null)
            {

                shoe.Price = model.Price;
                shoe.Color = model.Color;
                shoe.Model = model.Name;
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
            List<ShoeAddViewModel> entities = repository.AllReadOnly<Shoe>()
                .Select(s => new ShoeAddViewModel()
                {
                    Id = s.Id,
                    Name = s.Model,
                    ImageUrl = s.ImageUrl,
                    Price = s.Price,
                    BrandId = s.BrandId,
                    TypeId = s.TypeId,
                    Color = s.Color,
                })
                .ToList();

            var existingModel = entities.FirstOrDefault(s => s.Name == model.Name);
            if (existingModel != null)
            {

                return true;
            }
            return false;
        }
        public async Task<List<SizeViewModel>> GetSizeViewModels(int shoeId)
        {
            var availableSizes = await repository.All<ShoeSize>()
               .Where(g => g.ShoeId == shoeId)
               .Select(s => new SizeViewModel()
               {

                   Name = s.Size.ToString()
               })
               .ToListAsync();
            return availableSizes;
        }

        public async Task SoftDelete(int id)
        {
            var entity = await repository.GetByIdAsync<Shoe>(id);
            entity.IsActive = false;
            await repository.UpdateAsync(entity);
            await repository.SaveChangesAsync();
        }
    }
}
