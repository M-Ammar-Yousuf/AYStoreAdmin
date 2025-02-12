﻿using Microsoft.EntityFrameworkCore;

namespace AYStoreAdmin.Models
{
    public class AYStoreDbContext : DbContext
    {
        public AYStoreDbContext(DbContextOptions<AYStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configurations

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");

            //configuration using Fluent API
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}
