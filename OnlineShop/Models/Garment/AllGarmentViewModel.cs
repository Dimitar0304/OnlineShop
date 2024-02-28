using OnlineShop.Infrastructure;
using OnlineShop.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Garment
{
    public class AllGarmentViewModel
    {
        public List<GarmentViewModel> Garments { get; set; } = new List<GarmentViewModel>();
        [Required]
        public string Season { get; set; } = "Winter";
    }
}
