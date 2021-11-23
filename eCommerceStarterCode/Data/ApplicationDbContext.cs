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

            _ = modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Rodney Harrison Jersey", Description = "Signed Rodney Harrison SuperBowl Jersey", Price = 7500, Category = "Football" },
                new Product { Id = 2, Name = "Peyton Manning Card", Description = "Rookie Card", Price = 500, Category = "Sports Cards" },
                new Product { Id = 3, Name = "Tom Brady Helmet", Description = "Signed Tom Brady Helmet", Price = 1000, Category = "Football" },
                new Product { Id = 4, Name = "Clinton Portis Jersey", Description = "Signed Clinton Portis Jersey", Price = 350, Category = "Football" },
                new Product { Id = 5, Name = "Basketball Jersey", Description = "Signed Paul Pierce Game 1 Finals Jersey", Price = 5000, Category = "Basketball" },
                new Product { Id = 6, Name = "Basketball Jersey", Description = "Signed Kevin Garnett Game 1 Finals Jersey", Price = 2500, Category = "Basketball" },
                new Product { Id = 7, Name = "Goalie Helmet", Description = "Signed Tuuka Rask Helmet", Price = 2500, Category = "Hockey" },
                new Product { Id = 8, Name = "Patrice Bergeron Hockey Stick", Description = "Signed Patrice Bergeron stick from Game 1 of Stanley Cup", Price = 10000, Category = "Hockey" },
                new Product { Id = 9, Name = "Curt Schilling Game Ball", Description = "Signed Curt Schilling Game Ball World Series", Price = 80000, Category = "Baseball" },
                new Product { Id = 10, Name = "David Ortiz Baseball Bat", Description = "Signed David Ortiz Baseball Bat", Price = 3000, Category = "Baseball" }
                );
        }

    }
}
