using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Order
{
    public class OrderDetailModel
    {
        public decimal Price { get; set; }

        public string UserId { get; set; } = null!;
        public string UserName { get; set; }=null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int PaymentMethodId { get; set; }
    }
}
