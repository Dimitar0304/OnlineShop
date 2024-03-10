using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.Type;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using OnlineShop.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Core.Models.Shoe
{
    /// <summary>
    /// Shoe add view model
    /// </summary>
    public class ShoeAddViewModel
    {
        /// <summary>
        /// Shoe view model Entity
        /// </summary>
        [Comment("Shoe view model entity")]

        /// <summary>
        /// Shoe Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Shoe Model
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(DataConstants.Shoe.MaxModelLenght
            , MinimumLength = DataConstants.Shoe.MinModelLenght
            , ErrorMessage = ErrorMessages.StringLenghtError)]
        [Display(Name = "Shoe Model")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Shoe Type Identifier
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name = "Shoe Type")]

        public int TypeId { get; set; }

        /// <summary>
        /// Shoe types view model 
        /// </summary>
        public IEnumerable<TypeAllViewModel> Types { get; set; } = new List<TypeAllViewModel>();

        /// <summary>
        /// Shoe Brand Identifier
        /// </summary>
        [Required]
        [Display(Name = "Shoe Brand")]
        public int BrandId { get; set; }

        /// <summary>
        /// Collection of all Brands
        /// </summary>
        public IEnumerable<BrandViewModel> Brands { get; set; } = new List<BrandViewModel>();

        /// <summary>
        /// Brand name
        /// </summary>
        public string BrandName { get; set; } = "Default";

        /// <summary>
        /// Shoe Price
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name = "Shoe Price")]
        [Range((0.00), 5000.00, ErrorMessage = ErrorMessages.PriceRangeErrorMessage)]
        public decimal Price { get; set; }

        /// <summary>
        /// Shoe Color
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(DataConstants.Shoe.MaxColorLenght,
            MinimumLength = DataConstants.Shoe.MinColorLenght
            , ErrorMessage = ErrorMessages.StringLenghtError)]
        [Display(Name = "Shoe color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// Shoe Image Url
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public string ImageUrl { get; set; } = null!;


    }

}

