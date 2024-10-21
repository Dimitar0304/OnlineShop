using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        SeedData seed = new SeedData();
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new List<IdentityRole> { seed.Admin,seed.User});
               
        }
    }
}
