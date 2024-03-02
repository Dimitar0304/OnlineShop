using OnlineShop.Infrastructure;
using OnlineShop.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Size
{
    /// <summary>
    /// Size view model
    /// </summary>
    public class SizeViewModel
    {
        /// <summary>
        /// Size view model identifier
        /// </summary>
        public int  Id { get; set; }


        /// <summary>
        /// Size name 
        /// </summary>
         [StringLength(DataConstants.Size.MaxLenght
            ,MinimumLength =DataConstants.Size.MinLenght
            ,ErrorMessage =ErrorMessages.StringLenghtError)]
        public string Name { get; set; } = null!;
    }
}
