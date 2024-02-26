using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    [Comment("Garment-size entity")]
    public class GarmentSize
    {
        [Required]
        [Comment("Garment identifier")]
        [ForeignKey(nameof(Garment))]
        public int GarmentId { get; set; }
        [Required]
        public Garment Garment { get; set; } = null!;
        [Required]
        [Comment("Size identifier")]
        [ForeignKey(nameof(Size))]
        public int SizeId { get; set; }
        [Required]
        public Size Size { get; set; } = null!;
    }
}
