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




                return db;
            }
        }
    }
}
