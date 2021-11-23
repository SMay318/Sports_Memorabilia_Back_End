using eCommerceStarterCode.Configuration;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStarterCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
     
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            modelBuilder.Entity<ShoppingCart>()
                .HasKey(sc => new { sc.ProductId, sc.UserId });

            modelBuilder.Entity<Review>()
                .HasKey(r=> new { r.ProductId });

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Jersey", Description = "Football jersey", Price = 180, Category = "Football"},
                new Product { Id = 2, Name = "Peyton Manning Card", Description = "Rookie Card", Price = 500, Category = "Sports Cards"});
        }

    }
}
