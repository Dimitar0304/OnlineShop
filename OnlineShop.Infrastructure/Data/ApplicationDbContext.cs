using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Data.Configuration;
using OnlineShop.Infrastructure.Data.Models;

namespace OnlineShop.Infrastructure
{
    /// <summary>
    /// ApplicationDb Context
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// ApplicationDb Context Ctor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Collection of Accessory
        /// </summary>
        public DbSet<Accessory> Accessories { get; set; } = null!;

        /// <summary>
        /// Collection of Garment
        /// </summary>
        public DbSet<Garment> Garments { get; set; } = null!;

        /// <summary>
        /// Collection of Shoe
        /// </summary>
        public DbSet<Shoe> Shoes { get; set; } = null!;

        /// <summary>
        /// Collection of Brand
        /// </summary>
        public DbSet<Brand> Brands { get; set; } = null!;

        /// <summary>
        /// Collection of GarmentSize
        /// </summary>
        public DbSet<GarmentSize> GarmentsSizes { get; set; } = null!;

        /// <summary>
        /// Collection of GarmentType
        /// </summary>
        public DbSet<GarmentType> GarmentsTypes { get; set; } = null!;

        /// <summary>
        /// Collection of Order
        /// </summary>
        public DbSet<Order> Orders { get; set; } = null!;

        /// <summary>
        /// Collection of ShoeSize
        /// </summary>
        public DbSet<ShoeSize> ShoesSizes { get; set; } = null!;

        /// <summary>
        /// Collection of ShoeType
        /// </summary>
        public DbSet<ShoeType> ShoesTypes { get; set; } = null!;

        /// <summary>
        /// Collection of Size
        /// </summary>
        public DbSet<Size> Sizes { get; set; } = null!;

        /// <summary>
        /// Collection of UserOrder
        /// </summary>
        public DbSet<UserOrder> UsersOrders { get; set; } = null!;

        /// <summary>
        /// Models configuration
        /// </summary>
        /// <param name="builder"></param>
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

            //Seeding brands  configuration
            builder.ApplyConfiguration(new BrandConfiguration());

            //Seed garment type configuration
            builder.ApplyConfiguration(new GarmentTypeConfiguration());

            //Seed identity roles configuration
            builder.ApplyConfiguration(new IdentityRolesConfiguration());

            //Seed payment method configuration
            builder.ApplyConfiguration(new PaymentMethodConfiguration());

            //Seed shoe type configuration
            builder.ApplyConfiguration(new ShoeTypeConfiguration());

            //Seed size configuration
            builder.ApplyConfiguration(new SizeConfiguration());

            //Seed Users
            builder.ApplyConfiguration(new UserConfiguration());

            ////Seed Garment
            builder.ApplyConfiguration(new GarmentConfiguration());

           

            //Seed Shoe 
            builder.ApplyConfiguration(new ShoeConfiguration());

            

            //Seed Accessories
            builder.ApplyConfiguration(new AccessoryConfiguration());

            base.OnModelCreating(builder);
        }
    }
}