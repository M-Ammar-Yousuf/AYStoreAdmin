using Microsoft.EntityFrameworkCore;

namespace AYStoreAdmin.Models
{
    public class AYStoreDbContext: DbContext
    {
        public AYStoreDbContext(DbContextOptions<AYStoreDbContext> options): base(options)
        {
            
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail>OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configurations

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");

            //configuration using Fluent API
            modelBuilder.Entity<Category>()
                .Property(p=> p.Name)
                .IsRequired();
        }
    }
}
