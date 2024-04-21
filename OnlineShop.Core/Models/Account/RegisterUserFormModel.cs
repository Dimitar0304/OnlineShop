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
        [Display(Name ="Username")]
        public string UserName { get; set; } = null!;
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.User.FirstNameMaxLenght,
            MinimumLength =DataConstants.User.FirstNameMinLenght
            )]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.User.LastNameMaxLenght,
            MinimumLength = DataConstants.User.LastNameMinLenght
            )]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage =ErrorMessages.PasswordRequired)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = ErrorMessages.PasswordRequired)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = null!;
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
    }
}
