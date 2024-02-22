using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models
{
    [Comment("Garment data entity")]
    public class Garment
    {
        [Key]
        [Comment("Garment identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.Garment.MaxModelLenght)]
        [Comment("Garment Name")]
        public string Model { get; set; } = null!;
        [Required]
        [Comment("Garment Type")]
        public GarmentType Type { get; set; } = null!;
        [Required]
        [Comment("Garment Brand identifier")]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Required]
        [Comment("Garment brand")]
        public Brand Brand { get; set; } = null!;
        [Required]
        [Comment("Garment price")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(DataConstants.Garment.MaxColorLenght)]
        [Comment("Color")]
        public string Color { get; set; } = null!;
        [Comment("Garment size collection")]
        public IEnumerable<GarmentSize> ClothesSizes { get; set; } = null!;
    }
}
