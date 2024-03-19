using OnlineShop.Core.Models.Size;

namespace OnlineShop.Core.Models.Garment
{
    /// <summary>
    /// Garment details view model
    /// </summary>
    public class GarmentDetailsViewModel
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public string Color { get; set; } = null!;
        public List<SizeViewModel> AvailableSizes { get; set; } = new List<SizeViewModel>();

    }
}
