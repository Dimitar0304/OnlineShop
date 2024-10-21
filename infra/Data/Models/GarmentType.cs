using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Garment Type Entity
    /// </summary>
    [Comment("Garment type entity")]
    public class GarmentType
    {
        /// <summary>
        /// Garment type Identifier
        /// </summary>
        [Key]
        [Comment("Garment type identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Garment Type Name
        /// </summary>
        [Required]
        [StringLength(DataConstants.GarmentType.MaxNameLenght)]
        [Comment("Garment type name")]
        public string Name { get; set; } = null!;
    }
}
