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
    }
}
