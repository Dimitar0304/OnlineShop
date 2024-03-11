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
