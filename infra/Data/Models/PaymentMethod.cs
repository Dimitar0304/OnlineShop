using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Payment Method Entity
    /// </summary>
    [Comment("PaymentMethod entity")]
    public class PaymentMethod
    {
        /// <summary>
        /// PaymentMethod identifier
        /// </summary>
        [Key]
        [Comment("PaymentMethod identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Payment Type (Card or Cash)
        /// </summary>
        [Required]
        [Comment("Payment Type")]
        public PaymentType PaymentType { get; set; }
    }
}
