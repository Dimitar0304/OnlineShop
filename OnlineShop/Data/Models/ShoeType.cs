using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    [Comment("Shoe type entity")]
    public class ShoeType
    {
        [Key]
        [Comment("Shoe type identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.ShoeType.MaxNameLenght)]
        public string Name { get; set; } = null!;
    }
}
