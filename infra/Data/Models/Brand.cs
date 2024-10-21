using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Infrastructure.Data.Models
{

    /// <summary>
    /// Brand Data Entity
    /// </summary>
    [Comment("Brand data entity")]
    public class Brand
    {
        /// <summary>
        /// Brand Identifier
        /// </summary>
        [Key]
        [Comment("Brand identifier")]
        public int Id { get; set; }
        
        /// <summary>
        /// Brand Name
        /// </summary>
        [Required]
        [StringLength(DataConstants.Brand.MaxNameLenght)]
        [Comment("Brand Name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Brand Garment Collection
        /// </summary>
        public IEnumerable<Garment> Garments { get; set; } = null!;

        /// <summary>
        /// Brand Shoe Colllection
        /// </summary>
        public IEnumerable<Shoe> Shoes { get; set; } = null!;

        /// <summary>
        /// Brand Accessory Collection
        /// </summary>
        public IEnumerable<Accessory> Accessories { get; set; } = null!;
    }
}
