using OnlineShop.Infrastructure;
using System.Security.Claims;

namespace OnlineShop.Extentions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string Id(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(DataConstants.AdminConstants.AdminRoleName);
        }

    }
}
