using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Garment Size Entity
    /// </summary>
    [Comment("Garment-size entity")]
    public class GarmentSize
    {
        /// <summary>
        /// Garment Identifier
        /// </summary>
        [Required]
        [Comment("Garment identifier")]
        [ForeignKey(nameof(Garment))]
        public int GarmentId { get; set; }

        /// <summary>
        /// Garment Type
        /// </summary>
        [Required]
        public Garment Garment { get; set; } = null!;

        /// <summary>
        /// Size Identifier
        /// </summary>
        [Required]
        [Comment("Size identifier")]
        [ForeignKey(nameof(Size))]
        public int SizeId { get; set; }

        /// <summary>
        /// Size Type
        /// </summary>
        [Required]
        public Size Size { get; set; } = null!;

        /// <summary>
        /// GarmentSize Quantity
        /// </summary>
        [Required]
        [Comment("GarmentSize Quantity")]
        public int Quantity { get; set; }
    }
}
