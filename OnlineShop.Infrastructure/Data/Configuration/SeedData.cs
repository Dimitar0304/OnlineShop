using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    internal class SeedData
    {
        public User justUser { get; set; }
        public User justAdmin { get; set; }

        public Garment lacosteSweatshirt { get; set; }
        public Shoe airMax97 { get; set; }
        public Accessory acr1 { get; set; }
        public Accessory arc2 { get; set; }
        public Accessory arc3 { get; set; }
        public Accessory arc4 { get; set; }

        public IdentityRole User { get; set; }
        public IdentityRole Admin { get; set; }

        

        public List<GarmentSize> GarmentSizes { get; set; } = new List<GarmentSize>();

        public List<ShoeSize> ShoeSizes { get; set; } = new List<ShoeSize>();

        public SeedData()
        {
            SeedUsers();
            SeedRoles();

            SeedGarments();
            SeedShoes();
            SeedAccessories();

            

        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<User>();

             justUser = new User()
            {
                Id = "bb77b48a-3afa-4050-8b2e-1847bbe5413b",
                UserName = "JustUser4e",
                NormalizedUserName = "JUSTUSER4E",
                Email = "JustUser@mail.com",
                NormalizedEmail = "JUSTUSER@mail.com",
                RegistrationDate = DateTime.Now,
                FirstName = "Just",
                LastName = "User4e",
               
                EmailConfirmed = true,
               
               


            };
            justUser.PasswordHash = hasher.HashPassword(justUser, "User123");
            

            //Admin user
             justAdmin = new User()
            {
                Id = "250f8800-ede3-4210-a8d0-8a0353a67e24",
                UserName = "JustAdmin4e",
                NormalizedUserName = "JUSTADMIN4E",
                Email = "JustAdmin@mail.com",
                NormalizedEmail = "JUSTADMIN@mail.com",
                RegistrationDate = DateTime.Now,
                FirstName = "Just",
                LastName = "Admin4e",
                
                EmailConfirmed = true,
               

            };
            justAdmin.PasswordHash = hasher.HashPassword(justAdmin, "Admin123");
        }


        private void SeedGarments()
        {
             lacosteSweatshirt = new Garment()
            {
                Id = 1,
                Model = "Zip Sweatshirts",
                BrandId = 3,
                TypeId = 7,
                Color = "DarkBlue",
                ImageUrl = "https://i.pinimg.com/564x/93/d7/b2/93d7b28cfb66f9daa650559600a0abd1.jpg",
                Price = 100.00m,
                IsActive = true,
                

            };
        }

        private void SeedShoes()
        {
             airMax97 = new Shoe()
            {
                Id = 1,
                BrandId = 1,
                TypeId = 1,
                Color = "Black and White",
                ImageUrl = "https://i.pinimg.com/564x/f7/0c/21/f70c21947cf4630a184d9728e7077bdf.jpg",
                IsActive = true,
                Price = 420.00m,
                Model = "Nike Air Max 97"

            };
        }
        private void SeedRoles()
        {
            User = new IdentityRole()
            {
                Name ="User",
                NormalizedName = "User",
                Id = "322a7bf2-124a-4ce7-bdf8-43eba64446b5"
            };
            Admin = new IdentityRole()
            {
               Name="Admin",
               NormalizedName = "Admin",
               Id = "f05308b9-55ff-4b20-8e57-9a2b89573525"
            };
        }
        private void SeedAccessories()
        {
             acr1 = new Accessory()
            {
                Id = 1,
                ImageUrl = "https://i.pinimg.com/564x/f5/7f/c3/f57fc31f3e0629c3ef481e8459e99cf0.jpg",
                Name = "Champion winter hat",
                BrandId = 5,
                Type = "Hat",
                IsActive = true,
                Price = 30.00m,
                Quantity = 5
            };
           
             arc2 = new Accessory()
            {
                Id = 2,
                Name = "Nike cap",
                ImageUrl = "https://i.pinimg.com/564x/90/52/13/905213317d3bed8971d4164f0323fb04.jpg",
                Price = 45.00m,
                Quantity = 5,
                IsActive = true,
                Type = "Cap",
                BrandId = 1
            };
            

             arc3 = new Accessory()
            {
                Id = 3,
                Name = "Nike Thermo Mask",
                ImageUrl = "https://i.pinimg.com/564x/60/32/b3/6032b3977c6e276780b9b39d89ac705a.jpg",
                Price = 50.00m,
                Quantity = 5,
                IsActive = true,
                BrandId = 1,
                Type = "Mask",

            };
            
             arc4 = new Accessory()
            {
                Id = 4,
                Name = "Nike long socks",
                ImageUrl = "https://i.pinimg.com/564x/e9/b7/ce/e9b7ceb439600eb81285255fa00ce157.jpg",
                BrandId = 1,
                IsActive = true,
                Quantity = 10,
                Price = 20.00m,
                Type = "Socks"
            };
            
        }

       


       
    }
}

