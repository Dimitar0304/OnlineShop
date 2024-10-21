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
        SeedData seed = new SeedData();
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new List<User>() { seed.justUser, seed.justAdmin });
        }
    }
}
