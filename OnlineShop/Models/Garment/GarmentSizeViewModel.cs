using OnlineShop.Infrastructure;
using OnlineShop.Models.Size;
using OnlineShop.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Garment
{

    /// <summary>
    /// Garment size view model for adding in cart
    /// </summary>
    public class GarmentSizeViewModel
    {
        /// <summary>
        /// List of possible sizes
        /// </summary>
        public List<SizeViewModel> Sizes { get; set; } = new List<SizeViewModel>();

        /// <summary>
        /// Garment identifier
        /// </summary>
        public int GarmentId { get; set; }

        /// <summary>
        /// Size identifier
        /// </summary>
        public int SizeId { get; set; }
    }
}
