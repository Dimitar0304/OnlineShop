using OnlineShop.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core.Models.User
{
    public class LoginFormModel
    {
        [Required
            (ErrorMessage =ErrorMessages.UserNameRequired)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;
        [Required
            (ErrorMessage=ErrorMessages.PasswordRequired)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

    }
}
