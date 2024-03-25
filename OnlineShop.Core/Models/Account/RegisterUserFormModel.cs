using OnlineShop.Infrastructure;
using OnlineShop.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.Account
{
    public class RegisterUserFormModel
    {
        [Required
            (ErrorMessage =ErrorMessages.UserNameRequired)]
        public string UserName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.User.FirstNameMaxLenght,
            MinimumLength =DataConstants.User.FirstNameMinLenght
            )]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.User.LastNameMaxLenght,
            MinimumLength = DataConstants.User.LastNameMinLenght
            )]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage =ErrorMessages.PasswordRequired)]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = ErrorMessages.PasswordRequired)]
        public string ConfirmPassword { get; set; } = null!;
        
        public string? PhoneNumber { get; set; }
    }
}
