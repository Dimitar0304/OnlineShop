using OnlineShop.Core.Services.Contracts;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services.ShoeService
{
    /// <summary>
    /// Shoe size service
    /// </summary>
    public class ShoeSizeService : IShoeSizeService
    {
        private readonly IRepository repository;
        public ShoeSizeService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Method for add shoeSize model with each size
        /// </summary>
        /// <param name="shoeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddShoeSizeModels(int id)
        {
            for (int i = 33; i < 56; i++)
            {
                var shoeSize = new ShoeSize()
                {
                    Size = i,
                    ShoeId = id,
                    Quantity = 10,
                    

                };
                await repository.AddAsync(shoeSize);
            }
        }
    }
}
