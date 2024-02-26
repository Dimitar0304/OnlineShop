using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Size for Clothes entities
    /// </summary>
    [Comment("Size for clothes entities")]
    public  class Size
    {
        /// <summary>
        /// SizeClothes Identifier
        /// </summary>
        [Key]
        [Comment("Size identifier")]
        public int Id { get; set; }

        /// <summary>
        /// SizeClothes Name
        /// </summary>
        [Required]
        [StringLength(DataConstants.Size.MaxLenght)]
        [Comment("Size Name")]
        public string Name { get; set; } = null!;
        
    }
}
