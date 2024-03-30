using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services.AccessoryService
{
    /// <summary>
    /// Accessory service class
    /// </summary>
    public class AccessoryService : IAccessoryService
    {
        /// <summary>
        /// Inject repository in service using dependency injection
        /// </summary>
        private readonly IRepository repository;
        public AccessoryService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Check Is accessory exist in db 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AccessoryIsExistInDb(AccessoryAddViewModel model)
        {
            List<AccessoryAddViewModel> entities = repository.AllReadOnly<Accessory>()
                .Select(s => new AccessoryAddViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ImageUrl,
                    Price = s.Price,
                    BrandId = s.BrandId,
                    Type = s.Type,

                })
                .ToList();


            if (entities.Contains(model))
            {

                return true;
            }
            return false;
        }

        /// <summary>
        /// Method for add accessory to db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddAccessoryToDbAsync(AccessoryAddViewModel model)
        {
            if (model != null)
            {
                var entity = new Accessory()
                {
                    Id = model.Id,
                    Name = model.Name,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    BrandId = model.BrandId,
                    IsActive = true,
                    Type = model.Type,
                    Quantity = 10,
                };
                await repository.AddAsync(entity);
            }
        }

        /// <summary>
        /// Method for delete accessory 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAccessoryToDbAsync(int id)
        {
            var accessory = repository.GetByIdAsync<Accessory>(id);

            repository.Delete(accessory);
        }

        /// <summary>
        /// Method for get all accessories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<AccessoryAllViewModel>> GetAllAccessoryAsync()
        {
            return await repository.All<Accessory>()
                .Where(a => a.IsActive == true)
                 .Select(a => new AccessoryAllViewModel()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     ImageUrl = a.ImageUrl,
                     Price = a.Price,
                     BrandName = a.Brand.Name,
                     Type = a.Type,

                 })
                 .ToListAsync();
        }


        /// <summary>
        /// Method for get Brands
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
        /// Method for get accessory entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AccessoryAddViewModel> GetByIdAsync(int id)
        {
            var accessory = await repository.GetByIdAsync<Accessory>(id);

            return new AccessoryAddViewModel()
            {
                Id = accessory.Id,
                Name = accessory.Name,
                ImageUrl = accessory.ImageUrl,
                Price = accessory.Price,
                Type = accessory.Type,
                BrandId = accessory.BrandId
            };
        }

        public async Task SoftDelete(int id)
        {
            var entity = await repository.GetByIdAsync<Accessory>(id);
            entity.IsActive = false;
            await repository.UpdateAsync(entity);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Method for update accessory in db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateAccessoryToDbAsync(AccessoryAddViewModel model)
        {
            var accessory = await repository.GetByIdAsync<Accessory>(model.Id);

            if (accessory != null)
            {

                accessory.Name = model.Name;
                accessory.ImageUrl = model.ImageUrl;
                accessory.Price = model.Price;
                accessory.Type = model.Type;
                accessory.BrandId = model.BrandId;
            }
            await repository.UpdateAsync<Accessory>(accessory);



        }
    }
}
