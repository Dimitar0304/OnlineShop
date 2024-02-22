using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Data.Models
{
    [Comment("User shoping cart entity")]
    public class UserShopingCart
    {
        
        [Comment("User  identifier")]
        public int UserId { get; set; }
        [Comment("User type")]
        public IdentityUser User { get; set; } = null!;

    }
}
