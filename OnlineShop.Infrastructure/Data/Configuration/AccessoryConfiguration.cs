using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class AccessoryConfiguration : IEntityTypeConfiguration<Accessory>
    {
        public void Configure(EntityTypeBuilder<Accessory> builder)
        {
            builder.HasData(SeedAccessories());
        }
        private List<Accessory> SeedAccessories()
        {
            var accessories = new List<Accessory>();

            var acr1 = new Accessory()
            {
                Id = 1,
                ImageUrl = "https://i.pinimg.com/564x/f5/7f/c3/f57fc31f3e0629c3ef481e8459e99cf0.jpg",
                Name = "Champion winter hat",
                BrandId = 5,
                Type = "Hat",
                IsActive = true,
                Price = 30.00m,
                Quantity = 5
            };
            accessories.Add(acr1);
            var arc2 = new Accessory()
            {
                Id = 2,
                Name = "Nike cap",
                ImageUrl = "https://i.pinimg.com/564x/90/52/13/905213317d3bed8971d4164f0323fb04.jpg",
                Price = 45.00m,
                Quantity = 5,
                IsActive = true,
                Type = "Cap",
                BrandId = 1
            };
            accessories.Add(arc2);

           var arc3 = new Accessory()
           {
               Id = 3,
               Name = "Nike Thermo Mask",
               ImageUrl = "https://i.pinimg.com/564x/60/32/b3/6032b3977c6e276780b9b39d89ac705a.jpg",
               Price = 50.00m,
               Quantity = 5,
               IsActive = true,
               BrandId= 1,
               Type = "Mask",
               
           };
            accessories.Add(arc3);
            var arc4 = new Accessory()
            {
                Id = 4,
                Name = "Nike long socks",
                ImageUrl = "https://i.pinimg.com/564x/e9/b7/ce/e9b7ceb439600eb81285255fa00ce157.jpg",
                BrandId = 1,
                IsActive = true,
                Quantity = 10,
                Price = 20.00m,
                Type = "Socks"
            };
            accessories.Add(arc4);
            return accessories;
        }
    }
}
