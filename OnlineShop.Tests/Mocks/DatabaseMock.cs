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

                //setup accessory model in db 
                db.Accessories.Add(new Accessory()
                {
                    Name = TestConstants.AccessoryConstants.Name,
                    Type = TestConstants.AccessoryConstants.Type,
                    BrandId = TestConstants.AccessoryConstants.BrandId,
                    ImageUrl = TestConstants.AccessoryConstants.ImageUrl,
                    IsActive = TestConstants.AccessoryConstants.IsActive,
                    Price = TestConstants.AccessoryConstants.Price,
                    Quantity = TestConstants.AccessoryConstants.Quantity
                });

                db.SaveChanges();



                return db;
            }
        }
    }
}
