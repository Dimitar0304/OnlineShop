using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class AccessoryConfiguration : IEntityTypeConfiguration<Accessory>
    {
        SeedData seed = new SeedData();
        public void Configure(EntityTypeBuilder<Accessory> builder)
        {
            builder.HasData(new List<Accessory>() { seed.acr1, seed.arc2, seed.arc3, seed.arc4 });
        }
      
    }
}
