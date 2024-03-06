﻿using Microsoft.EntityFrameworkCore;
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
                    Model = model.Model,
                    TypeId = model.TypeId,
                    BrandId = model.BrandId,
                    Price = model.Price,
                    Color = model.Color,

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
                .All<Garment>().Select(g => new GarmentViewModel()
                {
                    Id = g.Id,
                    Model = g.Model,
                    TypeId = g.TypeId,
                    BrandId = g.BrandId,
                    Price = g.Price,
                    Color = g.Color,
                    ImageUrl = g.ImageUrl,
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
                Model = g.Model,
                TypeId = g.TypeId,
                BrandId = g.BrandId,
                Price = g.Price,
                Color = g.Color

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
                g.Model = model.Model;
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
            return await repository.All<ShoeType>()
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
        public async Task AddGarmentWithSizeToDb(int sizeId, int garmentId)
        {
            var model = new GarmentSize()
            {
                GarmentId = garmentId,
                SizeId = sizeId
            };
            await repository.AddAsync(model);
            await repository.SaveChangesAsync();
        }
    }
}
