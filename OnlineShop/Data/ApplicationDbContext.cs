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
                .HasOne(e=>e.User)
                .WithMany(e=>e.UsersOrders)
            base.OnModelCreating(builder);
        }
    }
}