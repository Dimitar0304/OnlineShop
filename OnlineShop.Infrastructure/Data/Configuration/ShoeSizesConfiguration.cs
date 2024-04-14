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
    public class ShoeSizesConfiguration : IEntityTypeConfiguration<ShoeSize>
    {
        public void Configure(EntityTypeBuilder<ShoeSize> builder)
        {
            builder.HasData(SeedShoeSizes());
        }
        private List<ShoeSize> SeedShoeSizes()
        {
            var ss= new List<ShoeSize>();
            for (int i = 30; i < 50; i++)
            {
                ss.Add(
                new ShoeSize()
                {
                    ShoeId =1,
                    Size = i,
                });
            }
            return ss;
        }
    }
}
