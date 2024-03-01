using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(new Brand()
            {
                Id = 1,
                Name = "Nike",

            },
                 new Brand()
                 {
                     Id = 2,
                     Name = "Adidas"
                 },
                 new Brand()
                 {
                     Id = 3,
                     Name = "LaCoste"
                 },
                 new Brand()
                 {
                     Id = 4,
                     Name = "Under Armour"
                 },
                 new Brand()
                 {
                     Id = 5,
                     Name = "Champion"
                 });
        }
    }
}
