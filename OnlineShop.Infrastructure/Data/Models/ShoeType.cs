using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Infrastructure;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Shoe Type Entity
    /// </summary>
    [Comment("Shoe type entity")]
    public class ShoeType
    {
        /// <summary>
        /// Shoe Type Identifier
        /// </summary>
        [Key]
        [Comment("Shoe type identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Shoe Type Name
        /// </summary>
        [Required]
        [StringLength(DataConstants.ShoeType.MaxNameLenght)]
        [Comment("Shoe type name")]
        public string Name { get; set; } = null!;
    }
}
