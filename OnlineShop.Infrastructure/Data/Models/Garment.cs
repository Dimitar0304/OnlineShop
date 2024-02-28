using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Garment Data Entity
    /// </summary>
    [Comment("Garment data entity")]
    public class Garment
    {
        /// <summary>
        /// Garment Identifier
        /// </summary>
        [Key]
        [Comment("Garment identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Garment Name
        /// </summary>
        [Required]
        [StringLength(DataConstants.Garment.MaxModelLenght)]
        [Comment("Garment Name")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Garment Type Identifier
        /// </summary>
        [Required]
        [Comment("Garment Type identifier")]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; } 
        
        /// <summary>
        /// Garment Type Type
        /// </summary>
        [Required]
        [Comment("Garment Type")]
        public GarmentType Type { get; set; } = null!;

        /// <summary>
        /// Garment Brand Identifier
        /// </summary>
        [Required]
        [Comment("Garment Brand identifier")]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        /// <summary>
        /// Garment Brand Type
        /// </summary>
        [Required]
        [Comment("Garment brand")]
        public Brand Brand { get; set; } = null!;

        /// <summary>
        /// Garment Price
        /// </summary>
        [Required]
        [Comment("Garment price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Garment Color
        /// </summary>
        [Required]
        [StringLength(DataConstants.Garment.MaxColorLenght)]
        [Comment("Color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// Garment Image Url
        /// </summary>
        [Required]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Garment Size Collection
        /// </summary>
        [Comment("Garment size collection")]
        public IEnumerable<GarmentSize> ClothesSizes { get; set; } = null!;


    }
}
