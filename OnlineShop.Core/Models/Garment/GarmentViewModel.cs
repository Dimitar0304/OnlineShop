using OnlineShop.Core.Models.Type;
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
        [Display(Name ="Garment Model")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Garment Dto type identifier
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name ="Garment Type")]
        public int TypeId { get; set; }

        /// <summary>
        /// Garment Types
        /// </summary>
        public IEnumerable<TypeAllViewModel> Types { get; set; }=new List<TypeAllViewModel>();

        /// <summary>
        /// Garment Dto brand identifier
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name ="Garment Brand")]
        public int BrandId { get; set; }

        /// <summary>
        /// Brand name
        /// </summary>
        public string BrandName { get; set; } = null!;

        /// <summary>
        /// Garments brands
        /// </summary>
        public List<BrandViewModel> Brands { get; set; } = new List<BrandViewModel>();

        /// <summary>
        /// Garment Dto price
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name ="Garment Price")]
        [Range(0.00,5000.00,ErrorMessage =ErrorMessages.PriceRangeErrorMessage)]
        public decimal Price { get; set; }

        /// <summary>
        /// Garment Dto color
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(DataConstants.Garment.MaxColorLenght
            , MinimumLength = DataConstants.Garment.MinColorLenght
            , ErrorMessage = ErrorMessages.StringLenghtError)]
        [Display(Name ="Garment Color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// image url
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name = "Garment Image")]
        public string ImageUrl { get; set; } = null!;
    }
}
