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
    public class GarmentConfiguration : IEntityTypeConfiguration<Garment>
    {
        public void Configure(EntityTypeBuilder<Garment> builder)
        {
            builder.HasData(SeedGarments());
        }
        private List<Garment> SeedGarments()
        {
            var garments= new List<Garment>();

            var lacosteSweatshirt = new Garment()
            {
                Id = 1,
                Model = "Zip Sweatshirts",
                BrandId = 3,
                TypeId = 7,
                Color = "Dark Blue",
                ImageUrl = "https://i.pinimg.com/564x/93/d7/b2/93d7b28cfb66f9daa650559600a0abd1.jpg",
                Price = 100.00m,
                IsActive = true
                
            };
            garments.Add(lacosteSweatshirt);

            return garments;    
        }
    }
}
