using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class GarmentSizeConfiguration : IEntityTypeConfiguration<GarmentSize>
    {
        public void Configure(EntityTypeBuilder<GarmentSize> builder)
        {
            builder.HasData(SeedGarmentSizes());
        }
        private List<GarmentSize> SeedGarmentSizes()
        {
            var gs = new List<GarmentSize>();

            var sizes = new List<Size>()
            {
                new Size()
                 {
                    Id = 1,
                Name = "S"

            },

            new Size()
            {
                Id = 2,
                Name = "XS"
            },
            new Size()
            {
                Id = 3,
                Name = "M"
            },
            new Size()
            {
                Id = 4,
                Name = "L"
            },
            new Size()
            {
                Id = 5,
                Name = "XL"
            },
            new Size()
            {
                Id = 6,
                Name = "XXL"
            },
            new Size()
            {
                Id = 7,
                Name = "XXXL"
            }
        };
            foreach (var s in sizes)
            {
                gs.Add(new GarmentSize()
                {
                    GarmentId = 1,
                    SizeId = s.Id
                });
            }
            return gs;

            

           
            
            
        }
    }
}
