using Microsoft.AspNetCore.Identity;
using OnlineShop.Services.Contracts;
using OnlineShop.Validations;

namespace OnlineShop.Core.Services.RoleService
{
    /// <summary>
    /// App Roles Service
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// private user manager field
        /// </summary>
        private readonly UserManager<IdentityUser> userManager;

        /// <summary>
        /// private role manager field
        /// </summary>
        private readonly RoleManager<IdentityRole> roleManager;


        /// <summary>
        /// Role manager service constructor with Dependency injection
        /// </summary>
        /// <param name="_userManager">private field for user manager</param>
        /// <param name="_roleManager">private field for role manager</param>
        public RoleService(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;

        }

        /// <summary>
        /// Method for adding a role to user
        /// </summary>
        /// <param name="userId">Input for user identifier</param>
        /// <param name="roleName">Input for role name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task AddUserToRole(string userId, string roleName)
        {
            if (userId != null || roleName != null)
            {
               
                var user = await userManager.FindByIdAsync(userId);
                //check user exist

                if (user == null)
                {
                    throw new ArgumentNullException();
                }
                //check role exist

                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    throw new ArgumentNullException();
                }
                //check currentUser is in currentRole

                if (await userManager.IsInRoleAsync(user, roleName))
                {
                    throw new ArgumentException(ErrorMessages.UserIsInThatRoleError);
                }
                //best case if all is right and add the role to user

                await userManager.AddToRoleAsync(user, roleName);
            }
            
            
        }
    }
}
