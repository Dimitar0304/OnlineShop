using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models.Order;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Core.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        public OrderService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<List<OrderDetailModel>> GetAllOrdersByUserId(string userId)
        {
           var models= await repository.All<Order>()
                .Where(o=>o.UserId == userId)
                .Select(o=>new OrderDetailModel()
                {
                    Price =o.Pice,
                    UserId =o.UserId,
                    Address = o.Address,
                    UserName = o.User.UserName,
                    PaymentMethodId =o.PaymentMethodId,
                    PhoneNumber = o.PhoneNumber,
                })
                .ToListAsync();

            return models;
        }

        public async Task<OrderDetailModel> GetOrderById(int id)
        {
          
           var model =await repository.All<Order>()
                .Select(o=>new OrderDetailModel()
                {
                    PaymentMethodId =o.PaymentMethodId,
                    Address = o.Address,
                    PhoneNumber=o.PhoneNumber,
                    Price =o.Pice,
                    UserId = o.UserId,
                    UserName = o.User.UserName,
                })
                .FirstOrDefaultAsync();
            return model;
        }
    }
}
