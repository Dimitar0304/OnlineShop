using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models
{
    [Comment("Shoe data entity")]
    public class Shoe
    {
        [Key]
        [Comment("Shoe identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.Shoe.MaxModelLenght)]
        [Comment("Shoe Model")]
        public string Model { get; set; } = null!;
        [Required]
        [Comment("Shoe type identifier")]
        [ForeignKey(nameof(ShoeType))]
        public int  TypeId { get; set; }
        [Required]
        [Comment("Shoe type type")]
        public ShoeType Type { get; set; }=null!;
        [Required]
        [Comment("Shoe brand identifier")]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Required]
        [Comment("Shoe brand type")]
        public Brand Brand { get; set; } = null!;
        [Required]
        [Comment("Shoe price")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(DataConstants.Shoe.MaxColorLenght)]
        [Comment("Shoe color")]
        public string Color { get; set; }= null!;
        public IEnumerable<ShoeSize> ShoesSizes { get; set; } = null!;
    }
}
