using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class ShoeConfiguration : IEntityTypeConfiguration<Shoe>
    {
        public void Configure(EntityTypeBuilder<Shoe> builder)
        {
            builder.HasData(SeedShoes());
        }

        private List<Shoe> SeedShoes()
        {
            var shoes = new List<Shoe>();

            var airMax97 = new Shoe()
            {
                Id= 1,
                BrandId = 1,
                TypeId= 1,
                Color = "Black and White",
                ImageUrl = "https://i.pinimg.com/564x/f7/0c/21/f70c21947cf4630a184d9728e7077bdf.jpg",
                IsActive = true,
                Price = 420.00m,
                Model = "Nike Air Max 97"
                
            };
            shoes.Add(airMax97);
            return shoes;
        }
    }
}
