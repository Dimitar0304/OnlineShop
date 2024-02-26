using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Infrastructure.Data.Models
{
    [Comment("Garment type entity")]
    public class GarmentType
    {
        [Key]
        [Comment("Garment type identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.GarmentType.MaxNameLenght)]
        [Comment("Garment type name")]
        public string Name { get; set; } = null!;
    }
}
