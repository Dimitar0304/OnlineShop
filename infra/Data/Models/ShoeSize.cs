using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure;

namespace OnlineShop.Infrastructure.Data.Models
{

    /// <summary>
    /// ShoeSize Data entity
    /// </summary>
    [Comment("Shoe-size data entity")]
    public class ShoeSize
    {
        /// <summary>
        /// Shoe Identifier
        /// </summary>
        [Required]
        [Comment("Shoe identifier")]
        [ForeignKey(nameof(Shoe))]
        public int ShoeId { get; set; }

        /// <summary>
        /// Shoe Type
        /// </summary>
        [Required]
        [Comment("Shoe type")]
        public Shoe Shoe { get; set; } = null!;

        /// <summary>
        /// Shoe Size
        /// </summary>
        [Required]
        [Comment("Shoe size")]
        public int Size { get; set; }

        /// <summary>
        /// ShoeSize Quantity
        /// </summary>
        [Required]
        [Comment("ShoeSize Quantity")]
        public int Quantity { get; set; }
    }
}