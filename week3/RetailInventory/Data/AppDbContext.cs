using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string for SQL Server LocalDB (installed with Visual Studio)
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=RetailInventoryDB;Trusted_Connection=true;MultipleActiveResultSets=true"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");

                // Configure relationship
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Category entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Groceries" },
                new Category { Id = 3, Name = "Clothing" },
                new Category { Id = 4, Name = "Books" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 75000, StockQuantity = 10, CategoryId = 1 },
                new Product { Id = 2, Name = "Rice Bag (5kg)", Price = 1200, StockQuantity = 50, CategoryId = 2 },
                new Product { Id = 3, Name = "Smartphone", Price = 45000, StockQuantity = 15, CategoryId = 1 },
                new Product { Id = 4, Name = "T-Shirt", Price = 800, StockQuantity = 30, CategoryId = 3 },
                new Product { Id = 5, Name = "Headphones", Price = 5000, StockQuantity = 20, CategoryId = 1 },
                new Product { Id = 6, Name = "Jeans", Price = 2500, StockQuantity = 25, CategoryId = 3 },
                new Product { Id = 7, Name = "Programming Book", Price = 1500, StockQuantity = 12, CategoryId = 4 }
            );
        }
    }
}