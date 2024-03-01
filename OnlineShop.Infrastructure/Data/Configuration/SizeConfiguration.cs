﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data.Configuration
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasData(new Size()
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
            });
        }
    }
}
