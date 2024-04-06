using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Garment;

namespace OnlineShop.Core.Models.Order
{
    public class OrderDetailModel
    {
        public decimal Price { get; set; }

        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int PaymentMethodId { get; set; }

        public List<GarmentSizeViewModel> Garments { get; set; } = new List<GarmentSizeViewModel>();
        public List<ShoeSizeViewModel> Shoes { get; set; } = new List<ShoeSizeViewModel>();
        public List<AccessoryDetailsViewModel> Accessories { get; set; } = new List<AccessoryDetailsViewModel>();
    }
}
