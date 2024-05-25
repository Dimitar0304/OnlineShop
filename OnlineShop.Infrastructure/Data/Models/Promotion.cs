using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Promotion data entity
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// Promotion identifier
        /// </summary>
        [Key]
        [Comment("Promotion identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Promotion name
        /// </summary>
        [Required]
        [Comment("Promotion name")]
        public string PromoName { get; set;} = null!;

        /// <summary>
        /// Promotion start date
        /// </summary>
        [Required]
        [Comment("Promotion start date")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Promotion end date
        /// </summary>
        [Required]
        [Comment("Promotion end date")]
        public DateTime End { get; set; }

        /// <summary>
        /// Promotion code
        /// </summary>
        [Required]
        [Comment("Promotion code")]
        public string PromoCode { get; set; } = null!;

        /// <summary>
        /// Promotion procentage
        /// </summary>
        [Required]
        [Comment("Promotion procentage")]
        public int PromotionProcentage { get; set; }
    }
}
