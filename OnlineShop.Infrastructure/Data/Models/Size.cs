using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Infrastructure.Data.Models
{
    [Comment("Size for clothes in shop")]
    public  class Size
    {
        [Key]
        [Comment("Size identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.Size.MaxLenght)]
        [Comment("Size Name")]
        public string Name { get; set; } = null!;
        
    }
}
