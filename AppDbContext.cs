using Microsoft.EntityFrameworkCore;
using product.Models;

namespace MyWebApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasDefaultSchema("metro");
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
           
        }
    }
}