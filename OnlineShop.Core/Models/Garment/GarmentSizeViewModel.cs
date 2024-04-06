using OnlineShop.Core.Models.Size;

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
        public string SizeName { get; set; } = null!;

        public decimal Price { get; set; }


    }
}
