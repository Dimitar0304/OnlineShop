using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure;
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
                
                   
                
                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}
