using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    [Comment("User order entity")]
    public class UserOrder
    {
        [Required]
        [Comment("User identifier")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }=null!;
        [Required]
        [Comment("User type")]
        public IdentityUser User { get; set; } = null!;
        [Required]
        [Comment("Order identifier")]
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; } 
        [Required]
        [Comment("Order type")]
        public Order Order { get; set; } = null!;
    }
}
