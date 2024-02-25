using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;

namespace OnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Accessory> Accessories { get; set; } = null!;
        public DbSet<Garment> Garments { get; set; } = null!;
        public DbSet<Shoe> Shoes { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<GarmentSize> GarmentsSizes { get; set; } = null!;
        public DbSet<GarmentType> GarmentsTypes { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<ShoeSize> ShoesSizes { get; set; } = null!;
        public DbSet<ShoeType> ShoesTypes { get; set; } = null!;
        public DbSet<Size> Sizes { get; set; } = null!;
        public DbSet<UserOrder> UsersOrders { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GarmentSize>()
                .HasKey(gs => new { gs.GarmentId, gs.SizeId });

            builder.Entity<ShoeSize>()
                .HasKey(ss => new {ss.ShoeId,ss.Size});
            builder.Entity<UserOrder>()
                .HasKey(uo=>new {uo.OrderId,uo.UserId});

            builder.Entity<UserOrder>()
                .HasOne(uo => uo.Order)
                .WithMany(uo => uo.UsersOrders)
                .OnDelete(DeleteBehavior.Restrict);

            //Seeding sizes 
            builder.Entity<Size>()
                .HasData(AddSizes());

            //Seeding sport brands
            builder.Entity<Brand>()
                .HasData(AddDistributedBrands());

            //Seeding roles
            builder.Entity<IdentityRole>()
                .HasData(AddIdentityRoles());

            base.OnModelCreating(builder);
        }
        private List<Size> AddSizes()
        {
            return new List<Size>() {
            new Size()
            {
                Id = 1,
                Name = "S"

            },

            new Size()
            {
                Id =2,
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
        }

        private List<Brand> AddDistributedBrands()
        {
            return new List<Brand>()
            {
                new Brand()
                {
                    Id = 1,
                    Name= "Nike",
                    
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
                }
            };
        }

        private List<IdentityRole> AddIdentityRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole("Admin"),
                new IdentityRole("User")
                
            };
        }
    }
}