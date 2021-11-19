using eCommerceStarterCode.Configuration;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStarterCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
     
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        
            //modelBuilder.Entity<Product>().HasData(
                //new Product() { ProductId = 1, ProductName = "", Description = "", Price = 0, Category = "", Reviews = "", Rating = 0},
                //new Product() { ProductId = 2, ProductName = "", Description = "", Price = 0, Category = "", Reviews = "", Rating = 0 },
        }

    }
}
