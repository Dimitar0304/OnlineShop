using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options
                    ;

                var db = new ApplicationDbContext(dbContextOptions);

                //Seed Garments
                db.Garments.AddAsync(
              new Infrastructure.Data.Models.Garment()
              {
                  Id = 1,
                  Model = TestConstants.GarmentConstants.Name,
                  BrandId = 1,
                  Color = TestConstants.GarmentConstants.Color,
                  ImageUrl = TestConstants.GarmentConstants.ImageUrl,
                  Price = TestConstants.GarmentConstants.Price,
                  IsActive = true,
                  TypeId = TestConstants.GarmentConstants.TypeId,

              });
                db.SaveChangesAsync();

                db.Brands.AddAsync(new Brand()
                {
                    Id = 1,
                    Name = "Nike"
                });
                db.SaveChangesAsync();

                db.GarmentsTypes.Add(new GarmentType()
                {
                    Id = 2,
                    Name="Shirt"
                });
                db.SaveChangesAsync();

                db.Sizes.Add(new Size()
                {
                    Id = 1,
                    Name = "S"
                });
                db.SaveChangesAsync();

                //Seed Shoes
                db.Shoes.Add(new Shoe()
                {
                    Id = 1,
                    Model = TestConstants.ShoeConstants.Name,
                    BrandId = 1,
                    TypeId = 2,
                    Color = TestConstants.ShoeConstants.Color,
                    ImageUrl = TestConstants.ShoeConstants.ImageUrl,
                    IsActive = true,
                    Price = TestConstants.ShoeConstants.Price,

                });
                db.SaveChangesAsync();

                //Seed Accessory
                db.Accessories.Add(new Accessory()
                {
                    Id = 1,
                    Name = TestConstants.AccessoryConstants.Name,
                    BrandId = 1,
                    Type = TestConstants.AccessoryConstants.Type,
                    Quantity = TestConstants.AccessoryConstants.Quantity,
                    ImageUrl = TestConstants.AccessoryConstants.ImageUrl,
                    IsActive = true,
                    Price = TestConstants.AccessoryConstants.Price
                    
                });
                db.SaveChangesAsync();

                db.ShoesTypes.Add(new ShoeType()
                {
                    Id = 2,
                    Name = "Sneakers",
                });
                db.SaveChangesAsync();


                return db;
            }
        }
    }
}
