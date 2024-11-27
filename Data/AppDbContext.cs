using ECommerceWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sample Product",
                    Price = 100,
                    Description = "Test Product",
                    ImageUrl = "Images/p2.jpg"
                },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20.99m, ImageUrl = "Images/p2.jpg" },
                new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 30.99m, ImageUrl = "Images/p3.jpg" }
            );

            // Seed data for Admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin" // Replace with hashed password
                }
            );
        }
    }
}
