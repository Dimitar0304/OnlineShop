using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Models.Garment;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Brand
{
    /// <summary>
    /// Brand Dto
    /// </summary>
    public class BrandViewModel
    {
        /// <summary>
        /// Brand Dto identifier
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Brand Dto Name
        /// </summary>
        
        public string Name { get; set; }

        public List<GarmentViewModel> Garments { get; set; }=new List<GarmentViewModel>();
        public List<AccessoryAddViewModel> Accessories { get; set; } = new List<AccessoryAddViewModel>();
        public List<ShoeAddViewModel> Shoes { get; set; } = new List<ShoeAddViewModel>();
    }
}
