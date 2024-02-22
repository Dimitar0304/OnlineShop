using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models
{
    [Comment("Accessory data entity")]
    public class Accessory
    {
        [Key]
        [Comment("Accessory identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.Accessory.MaxNameLenght)]
        [Comment("Accessory Name")]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.Accessory.MaxTypeLenght)]
        [Comment("Accessory Type")]
        public string Type { get; set; }=null!;
        [Required]
        [Comment("Accessory Price")]
        public decimal Price { get; set; }
        [Required]
        [Comment("Accessory brand identifier")]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Required]
        [Comment("Accessory brand type")]
        public Brand Brand { get; set; } = null!;
    }
}
