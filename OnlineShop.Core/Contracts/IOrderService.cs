using OnlineShop.Core.Models.Order;

namespace OnlineShop.Core.Contracts
{
    public interface IOrderService
    {
        public Task<OrderDetailModel> GetOrderById(int id);
        public Task<List<OrderDetailModel>> GetAllOrdersByUserId(string userId);
    }
}
