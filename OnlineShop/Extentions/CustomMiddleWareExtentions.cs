namespace OnlineShop.Extentions
{
    public  static class CustomMiddleWareExtentions
    {
        public static IApplicationBuilder UseAddAdmin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddAdminsToApp>();
        }
    }
}
