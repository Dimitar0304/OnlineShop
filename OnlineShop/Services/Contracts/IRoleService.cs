namespace OnlineShop.Services.Contracts
{
    public interface IRoleService
    {
        public  Task AddUserToRole(string userId,string roleName);

    }
}
