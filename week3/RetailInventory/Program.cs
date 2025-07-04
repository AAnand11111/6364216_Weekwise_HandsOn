using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Retail Inventory Management System ===");
            Console.WriteLine("Built with EF Core 8.0\n");

            try
            {
                using var context = new AppDbContext();

                // Ensure database is created and up to date
                Console.WriteLine("Setting up database...");
                await context.Database.EnsureCreatedAsync();
                Console.WriteLine("Database ready!\n");

                // Display menu
                await ShowMainMenu(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static async Task ShowMainMenu(AppDbContext context)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. View All Categories");
                Console.WriteLine("3. Find Product by ID");
                Console.WriteLine("4. Find Expensive Products (> ₹50,000)");
                Console.WriteLine("5. View Products by Category");
                Console.WriteLine("6. Add New Product");
                Console.WriteLine("7. Add New Category");
                Console.WriteLine("8. Update Product Stock");
                Console.WriteLine("9. Delete Product");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await DisplayAllProducts(context);
                        break;
                    case "2":
                        await DisplayAllCategories(context);
                        break;
                    case "3":
                        await FindProductById(context);
                        break;
                    case "4":
                        await FindExpensiveProducts(context);
                        break;
                    case "5":
                        await ViewProductsByCategory(context);
                        break;
                    case "6":
                        await AddNewProduct(context);
                        break;
                    case "7":
                        await AddNewCategory(context);
                        break;
                    case "8":
                        await UpdateProductStock(context);
                        break;
                    case "9":
                        await DeleteProduct(context);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // Lab 5: Retrieve Data Methods
        private static async Task DisplayAllProducts(AppDbContext context)
        {
            Console.WriteLine("\n=== ALL PRODUCTS ===");
            var products = await context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .ToListAsync();

            if (products.Any())
            {
                Console.WriteLine($"{"ID",-3} {"Name",-20} {"Price",-10} {"Stock",-8} {"Category",-15}");
                Console.WriteLine(new string('-', 60));

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id,-3} {product.Name,-20} ₹{product.Price,-9} {product.StockQuantity,-8} {product.Category.Name,-15}");
                }
                Console.WriteLine($"\nTotal Products: {products.Count}");
            }
            else
            {
                Console.WriteLine("No products found.");
            }
        }

        private static async Task DisplayAllCategories(AppDbContext context)
        {
            Console.WriteLine("\n=== ALL CATEGORIES ===");
            var categories = await context.Categories
                .Include(c => c.Products)
                .OrderBy(c => c.Name)
                .ToListAsync();

            if (categories.Any())
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id}. {category.Name} ({category.Products.Count} products)");
                }
            }
            else
            {
                Console.WriteLine("No categories found.");
            }
        }

        private static async Task FindProductById(AppDbContext context)
        {
            Console.Write("\nEnter Product ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = await context.Products
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    Console.WriteLine($"\nFound Product:");
                    Console.WriteLine($"ID: {product.Id}");
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Price: ₹{product.Price}");
                    Console.WriteLine($"Stock: {product.StockQuantity}");
                    Console.WriteLine($"Category: {product.Category.Name}");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        private static async Task FindExpensiveProducts(AppDbContext context)
        {
            Console.WriteLine("\n=== EXPENSIVE PRODUCTS (> ₹50,000) ===");
            var expensiveProducts = await context.Products
                .Include(p => p.Category)
                .Where(p => p.Price > 50000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            if (expensiveProducts.Any())
            {
                foreach (var product in expensiveProducts)
                {
                    Console.WriteLine($"{product.Name} - ₹{product.Price} ({product.Category.Name})");
                }
            }
            else
            {
                Console.WriteLine("No expensive products found.");
            }
        }

        private static async Task ViewProductsByCategory(AppDbContext context)
        {
            Console.WriteLine("\n=== PRODUCTS BY CATEGORY ===");
            var categories = await context.Categories
                .Include(c => c.Products)
                .OrderBy(c => c.Name)
                .ToListAsync();

            foreach (var category in categories)
            {
                Console.WriteLine($"\n{category.Name}:");
                if (category.Products.Any())
                {
                    foreach (var product in category.Products.OrderBy(p => p.Name))
                    {
                        Console.WriteLine($"  - {product.Name} (₹{product.Price}, Stock: {product.StockQuantity})");
                    }
                }
                else
                {
                    Console.WriteLine("  No products in this category.");
                }
            }
        }

        // Lab 4: Insert Data Methods
        private static async Task AddNewProduct(AppDbContext context)
        {
            Console.WriteLine("\n=== ADD NEW PRODUCT ===");

            // Show categories first
            var categories = await context.Categories.ToListAsync();
            Console.WriteLine("Available Categories:");
            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id}. {cat.Name}");
            }

            try
            {
                Console.Write("Product Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Price: ₹");
                decimal price = decimal.Parse(Console.ReadLine() ?? "0");

                Console.Write("Stock Quantity: ");
                int stock = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Category ID: ");
                int categoryId = int.Parse(Console.ReadLine() ?? "0");

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    StockQuantity = stock,
                    CategoryId = categoryId
                };

                context.Products.Add(product);
                await context.SaveChangesAsync();

                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
            }
        }

        private static async Task AddNewCategory(AppDbContext context)
        {
            Console.WriteLine("\n=== ADD NEW CATEGORY ===");

            try
            {
                Console.Write("Category Name: ");
                string name = Console.ReadLine() ?? "";

                var category = new Category { Name = name };

                context.Categories.Add(category);
                await context.SaveChangesAsync();

                Console.WriteLine("Category added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding category: {ex.Message}");
            }
        }

        private static async Task UpdateProductStock(AppDbContext context)
        {
            Console.WriteLine("\n=== UPDATE PRODUCT STOCK ===");

            try
            {
                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine() ?? "0");

                var product = await context.Products.FindAsync(id);
                if (product != null)
                {
                    Console.WriteLine($"Current stock for {product.Name}: {product.StockQuantity}");
                    Console.Write("New stock quantity: ");
                    int newStock = int.Parse(Console.ReadLine() ?? "0");

                    product.StockQuantity = newStock;
                    await context.SaveChangesAsync();

                    Console.WriteLine("Stock updated successfully!");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating stock: {ex.Message}");
            }
        }

        private static async Task DeleteProduct(AppDbContext context)
        {
            Console.WriteLine("\n=== DELETE PRODUCT ===");

            try
            {
                Console.Write("Product ID to delete: ");
                int id = int.Parse(Console.ReadLine() ?? "0");

                var product = await context.Products.FindAsync(id);
                if (product != null)
                {
                    Console.WriteLine($"Are you sure you want to delete '{product.Name}'? (y/n)");
                    string confirm = Console.ReadLine() ?? "";

                    if (confirm.ToLower() == "y")
                    {
                        context.Products.Remove(product);
                        await context.SaveChangesAsync();
                        Console.WriteLine("Product deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Delete cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
            }
        }
    }
}