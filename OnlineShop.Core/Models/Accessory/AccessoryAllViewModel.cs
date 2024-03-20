using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Accessory
{
    /// <summary>
    /// Accessory all view model for display all accessories
    /// </summary>
    public class AccessoryAllViewModel
    {
        public List<AccessoryAddViewModel> Accessories { get; set; }=new List<AccessoryAddViewModel>();
        public string Season { get; set; } = "Winter";

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
