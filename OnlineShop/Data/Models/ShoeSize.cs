using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models
{
    [Comment("Shoe-size mapping entity")]
    public class ShoeSize
    {
        [Required]
        [Comment("Shoe identifier")]
        [ForeignKey(nameof(Shoe))]
        public int ShoeId { get; set; }
        [Required]
        [Comment("Shoe type")]
        public Shoe Shoe { get; set; } = null!;
        [Required]
        [Comment("Shoe size")]
        public int Size { get; set; }
    }
}