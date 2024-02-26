using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Accessory Data Entity
    /// </summary>
    
    [Comment("Accessory data entity")]
    public class Accessory
    {
        /// <summary>
        /// Accessory Identifier
        /// </summary>
      
        [Key]
        [Comment("Accessory identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Accessory Name
        /// </summary>
        [Required]
        [StringLength(DataConstants.Accessory.MaxNameLenght)]
        [Comment("Accessory Name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Accessory Type
        /// </summary>
        [Required]
        [StringLength(DataConstants.Accessory.MaxTypeLenght)]
        [Comment("Accessory Type")]
        public string Type { get; set; }=null!;

        /// <summary>
        /// Accessory Price
        /// </summary>
        [Required]
        [Comment("Accessory Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Accessory Brand Identifier
        /// </summary>
        [Required]
        [Comment("Accessory brand identifier")]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        /// <summary>
        /// Accessory Brand Type
        /// </summary>
        [Required]
        [Comment("Accessory brand type")]
        public Brand Brand { get; set; } = null!;
    }
}
