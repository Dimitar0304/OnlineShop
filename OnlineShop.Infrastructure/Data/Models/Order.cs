using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Order Data Entity
    /// </summary>
    [Comment("Order data entity")]
    public class Order
    {
        /// <summary>
        /// Order Identifier
        /// </summary>
        [Comment("Order identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Order Price
        /// </summary>
        [Required]
        [Comment("Order Price")]
        public decimal Pice { get; set; }

        /// <summary>
        /// Order User Identifier
        /// </summary>
        [Required]
        [Comment("Order user identifier")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// Order User Type
        /// </summary>
        [Required]
        [Comment("Order user type")]
        public IdentityUser User { get; set; } = null!;

        /// <summary>
        /// Order PhoneNumber
        /// </summary>
        [Required]
        [Comment("Order phone number")]
        [MaxLength(DataConstants.Order.MaxPhoneNumberLenght)]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Order Address
        /// </summary>
        [Required]
        [Comment("Order Address")]
        [MaxLength(DataConstants.Order.MaxAddressLenght)]
        public string Address { get; set; } = null!;

        /// <summary>
        /// UserOrder Collection
        /// </summary>
        public IEnumerable<UserOrder> UsersOrders { get; set; } = new List<UserOrder>();

        /// <summary>
        /// Payment Method identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(PaymentMethod))]
        [Comment("Payment method identifier")]
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method type
        /// </summary>
        [Required]
        [Comment("Payment method type")]
        public PaymentMethod PaymentMethod { get; set; } = null!;
    }
}
