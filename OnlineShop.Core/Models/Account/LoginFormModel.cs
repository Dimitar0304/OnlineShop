using OnlineShop.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.User
{
    public class LoginFormModel
    {
        [Required
            (ErrorMessage =ErrorMessages.UserNameRequired)]
        public string UserName { get; set; } = null!;
        [Required
            (ErrorMessage=ErrorMessages.PasswordRequired)]
        public string Password { get; set; } = null!;

    }
}
