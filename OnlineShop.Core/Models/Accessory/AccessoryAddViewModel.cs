using OnlineShop.Infrastructure;
using OnlineShop.Models.Brand;
using OnlineShop.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Accessory
{
    /// <summary>
    /// Accessory all view model
    /// </summary>
    public class AccessoryAddViewModel
    {
        /// <summary>
        /// accessory identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Accessory Name
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(DataConstants.Accessory.MaxNameLenght
            , MinimumLength = DataConstants.Accessory.MinNameLenght
            , ErrorMessage = ErrorMessages.StringLenghtError)]
        [Display(Name = "Accessory Name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Accessory Type
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name ="Accessory Type")]
        [StringLength(DataConstants.Accessory.MaxTypeLenght
            ,MinimumLength =DataConstants.Accessory.MinTypeLenght
            ,ErrorMessage =ErrorMessages.StringLenghtError)]
        public string Type { get; set; } = null!;

        /// <summary>
        /// Accessory price
        /// </summary>
        [Required(ErrorMessage=ErrorMessages.RequiredField)]
        [Range(0.00,5000.00,ErrorMessage=ErrorMessages.PriceRangeErrorMessage)]
        [Display(Name ="Accessory Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Accessory Brand identifier
        /// </summary>
        [Required(ErrorMessage=ErrorMessages.RequiredField)]
        [Display(Name ="Accessory Brand")]
        public int BrandId { get; set; }
        /// <summary>
        /// Brand name
        /// </summary>
        public string BrandName { get; set; } = "Default";

        /// <summary>
        /// Collection of possible brands
        /// </summary>
        public IEnumerable<BrandViewModel>  Brands { get; set; } = new  List<BrandViewModel>();

        /// <summary>
        /// Accessory Image url 
        /// </summary>
        [Required(ErrorMessage =ErrorMessages.RequiredField)]
        [Display(Name ="Accessory Image Url")]
        public string ImageUrl { get; set; } = null!;
    }
}
