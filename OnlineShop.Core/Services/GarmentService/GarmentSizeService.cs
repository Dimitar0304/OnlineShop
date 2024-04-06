using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.Size;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services.GarmentService
{
    /// <summary>
    /// GarmentSize service 
    /// </summary>
    public class GarmentSizeService : IGarmentSizeService
    {
        private readonly IRepository repository;
        public GarmentSizeService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<GarmentSize> AddGarmentToCart(int sizeId, int garmentId)
        {
            //geting model
            var model = await repository.All<GarmentSize>()
                .FirstOrDefaultAsync(g=>g.GarmentId==garmentId
                &&g.SizeId==sizeId);

            //remove 1 garment of this garment with this size
            model.Quantity--;
            //Update to Db with removed quantity
            await repository.UpdateAsync(model);
            await repository.SaveChangesAsync();

            return model;

        }

        /// <summary>
        /// Method for add garmentSize model with each size in set
        /// </summary>
        /// <param name="garmentId"></param>
        /// <returns></returns>
        public async Task AddGarmentWithSizes(int garmentId)
        {
            var sizes = GetSizes();
            foreach (var size in sizes.Result)
            {
                var gs = new GarmentSize()
                {
                    GarmentId = garmentId,
                    SizeId = size.Id,
                    Quantity = 10
                };
               await repository.AddAsync(gs);
            }
        }

        /// <summary>
        /// Method for get all garment sizes
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
    }
}
