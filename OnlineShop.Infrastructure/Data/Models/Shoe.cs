using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Shoe Data Entity
    /// </summary>
    [Comment("Shoe data entity")]
    public class Shoe
    {
        /// <summary>
        /// Shoe Identifier
        /// </summary>
        [Key]
        [Comment("Shoe identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Shoe Model
        /// </summary>
        [Required]
        [StringLength(DataConstants.Shoe.MaxModelLenght)]
        [Comment("Shoe Model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Shoe Type Identifier
        /// </summary>
        [Required]
        [Comment("Shoe type identifier")]
        [ForeignKey(nameof(ShoeType))]
        public int  TypeId { get; set; }

        /// <summary>
        /// Shoe Type Type
        /// </summary>
        [Required]
        [Comment("Shoe type type")]
        public ShoeType Type { get; set; }=null!;

        /// <summary>
        /// Shoe Brand Identifier
        /// </summary>
        [Required]
        [Comment("Shoe brand identifier")]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        /// <summary>
        /// Shoe Brand Type
        /// </summary>
        [Required]
        [Comment("Shoe brand type")]
        public Brand Brand { get; set; } = null!;

        /// <summary>
        /// Shoe Price
        /// </summary>
        [Required]
        [Comment("Shoe price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Shoe Color
        /// </summary>
        [Required]
        [StringLength(DataConstants.Shoe.MaxColorLenght)]
        [Comment("Shoe color")]
        public string Color { get; set; }= null!;

        /// <summary>
        /// ShoeSize Collection
        /// </summary>
        public IEnumerable<ShoeSize> ShoesSizes { get; set; } = null!;
    }
}
