using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// UserOrder Entity
    /// </summary>
    [Comment("User order entity")]
    public class UserOrder
    {
        /// <summary>
        /// User Identifier
        /// </summary>
        [Required]
        [Comment("User identifier")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// User Type
        /// </summary>
        [Required]
        [Comment("User type")]
        public IdentityUser User { get; set; } = null!;

        /// <summary>
        /// Order Identifier
        /// </summary>
        [Required]
        [Comment("Order identifier")]
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; } 

        /// <summary>
        /// Order Type
        /// </summary>
        [Required]
        [Comment("Order type")]
        public Order Order { get; set; } = null!;
    }
}
