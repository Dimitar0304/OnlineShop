using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Contracts
{
    public interface  IShoppingCartService
    {
        public void RemoveItem(string productName);
        public decimal GetTotal();
    }
}
