using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly PasswordHasher<User> passwordHasher;
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<User> SeedUsers()
        {
            var users = new List<User>();
            var justUser = new User()
            {
                Id= "f2472cdf-c04e-47c7-9f72-1e6250c616f0",
                UserName = "JustUser4e",
                NormalizedUserName = "JustUser4e",
                Email = "JustUser@mail.com",
                NormalizedEmail = "JustUser@mail.com",
                RegistrationDate = DateTime.Now,
                FirstName = "Just",
                LastName= "User4e"
            };
            justUser.PasswordHash = passwordHasher.HashPassword(justUser,"user123");
            users.Add(justUser);

            //Admin user
            var justAdmin = new User()
            {
                Id = "4209a3eb-1085-40d4-9e52-5c008938393b",
                UserName = "JustAdmin4e",
                NormalizedUserName = "JustAdmin4e",
                Email = "JustAdmin@mail.com",
                NormalizedEmail = "JustAdmin@mail.com",
                RegistrationDate = DateTime.Now,
                FirstName = "Just",
                LastName = "Admin4e"
            };
            justAdmin.PasswordHash = passwordHasher.HashPassword(justAdmin, "admin123");
            users.Add(justAdmin);

            return users;

        }
    }
}
