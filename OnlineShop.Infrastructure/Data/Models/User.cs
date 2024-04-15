using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Custom Identity user class
    /// </summary>
    public class User:IdentityUser
    {
        /// <summary>
        /// User FirstName
        /// </summary>
        [MaxLength(DataConstants.User.FirstNameMaxLenght)]
        public string? FirstName { get; set; }

        /// <summary>
        /// User LastName
        /// </summary>
        [MaxLength(DataConstants.User.LastNameMaxLenght)]
        public string? LastName { get; set; } 

        /// <summary>
        /// User registration date
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// List of orders of User
        /// </summary>
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
