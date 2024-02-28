using OnlineShop.Services.Contracts;

namespace OnlineShop.Configurations
{
    /// <summary>
    /// Role configuration class for add admin of app
    /// </summary>
    public  class RoleConfiguration:ConfigurationProvider
    {

        private readonly IRoleService service;
        private const string roleName = "Admin";
        private const string userId = "35f2a7eb-994a-45a6-85b7-913d7e114fa9";

        public RoleConfiguration(IRoleService _service)
        {
            service = _service;

            service.AddUserToRole(userId, roleName);

        }
        public void AddAdmin()
        {

        }

    }
}
