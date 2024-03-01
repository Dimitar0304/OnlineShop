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
    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(new PaymentMethod()
            {
                Id = 1,
                PaymentType = Enums.PaymentType.Cash
            },
            new PaymentMethod()
            {
                Id = 2,
                PaymentType = Enums.PaymentType.Card
            });
        }
    }
}
