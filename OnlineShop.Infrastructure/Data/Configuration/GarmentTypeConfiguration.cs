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
    public class GarmentTypeConfiguration : IEntityTypeConfiguration<GarmentType>
    {
        public void Configure(EntityTypeBuilder<GarmentType> builder)
        {
            builder.HasData(new GarmentType()
            {
                Id = 1,
                Name = "Tshirt"
            },
                 new GarmentType()
                 {
                     Id = 2,
                     Name = "Shirt"
                 },
                 new GarmentType()
                 {
                     Id = 3,
                     Name = "Leggin"
                 },
                 new GarmentType()
                 {
                     Id = 4,
                     Name = "Pant"
                 },
                 new GarmentType()
                 {
                     Id = 5,
                     Name = "Jacket"
                 },
                 new GarmentType()
                 {
                     Id = 6,
                     Name = "Coat"
                 },
            new GarmentType()
            {
                Id = 7,
                Name = "Sweatshirts"
            });
        }
    }
}
