using OnlineShop.Infrastructure;
using OnlineShop.Models.Brand;
using OnlineShop.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Garment
{
    /// <summary>
    /// Garment view model
    /// </summary>
    public class GarmentViewModel
    {
        /// <summary>
        /// Garment Dto identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Garment Dto model
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(DataConstants.Garment.MaxModelLenght
            , MinimumLength = DataConstants.Garment.MinModelLenght
            , ErrorMessage = ErrorMessages.StringLenghtError)]
        public string Model { get; set; } = null!;
        /// <summary>
        /// Garment Dto type identifier
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int TypeId { get; set; }
        /// <summary>
        /// Garment Dto brand identifier
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int BrandId { get; set; }
        /// <summary>
        /// Garment Dto price
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public decimal Price { get; set; }
        /// <summary>
        /// Garment Dto color
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(DataConstants.Garment.MaxColorLenght
            , MinimumLength = DataConstants.Garment.MinColorLenght
            , ErrorMessage = ErrorMessages.StringLenghtError)]
        public string Color { get; set; } = null!;
        /// <summary>
        /// Garments brands
        /// </summary>

        public List<BrandViewModel> Brands { get; set; } = new List<BrandViewModel>();
    }
}
