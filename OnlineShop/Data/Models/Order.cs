using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models
{
    [Comment("Order data entity")]
    public class Order
    {
        [Comment("Order identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Order Price")]
        public decimal Pice { get; set; }
        [Required]
        [Comment("Order user identifier")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        [Required]
        [Comment("Order user type")]
        public IdentityUser User { get; set; } = null!;
        [Required]
        [Comment("Order phone number")]
        [MaxLength(DataConstants.Order.MaxPhoneNumberLenght)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [Comment("Order Address")]
        [MaxLength(DataConstants.Order.MaxAddressLenght)]
        public string Address { get; set; } = null!;
        public IEnumerable<UserOrder> UsersOrders { get; set; } = new List<UserOrder>();
    }
}
