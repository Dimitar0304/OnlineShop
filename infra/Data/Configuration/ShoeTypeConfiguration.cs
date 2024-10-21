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
    public class ShoeTypeConfiguration : IEntityTypeConfiguration<ShoeType>
    {
        public void Configure(EntityTypeBuilder<ShoeType> builder)
        {
            builder.HasData(new ShoeType()
            {
                Id = 1,
                Name = "Sneakers"
            },
                 new ShoeType()
                 {
                     Id = 2,
                     Name = "Boots"
                 },
                 new ShoeType()
                 {
                     Id = 3,
                     Name = "Basketball shoes"
                 },
                 new ShoeType()
                 {
                     Id = 4,
                     Name = "Football shoes"
                 });
        }
    }
}
