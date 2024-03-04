using OnlineShop.Services.Contracts;
using System.Runtime.CompilerServices;

namespace OnlineShop.Extentions
{
    /// <summary>
    /// Custom Middleware for add admin to my app
    /// </summary>
    public class AddAdminsToApp
    {
        
        /// <summary>
        /// private request delegate field
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Dependency injection principle
        /// </summary>
        /// <param name="_next"></param>
        public AddAdminsToApp(RequestDelegate _next)
        {
            next = _next;
         
        }

        /// <summary>
        /// Method for Invoke
        /// </summary>
        /// <param name="httpContext">Context</param>
        /// <param name="roleService">My role service</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext, IRoleService roleService)
        {
            await roleService.AddUserToRole("35f2a7eb-994a-45a6-85b7-913d7e114fa9", "Admin");
            await this.next(httpContext);
        }
       
    }
}
