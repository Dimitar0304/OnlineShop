using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    [Comment("Brand data entity")]
    public class Brand
    {
        [Key]
        [Comment("Brand identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.Brand.MaxNameLenght)]
        [Comment("Brand Name")]
        public string Name { get; set; } = null!;
        public IEnumerable<Garment> Garments { get; set; } = null!;
        public IEnumerable<Shoe> Shoes { get; set; } = null!;
        public IEnumerable<Accessory> Accessories { get; set; } = null!;
    }
}
