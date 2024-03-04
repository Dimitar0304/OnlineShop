using System.Security.Claims;

namespace OnlineShop.Extentions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string Id(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
