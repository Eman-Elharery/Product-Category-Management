using ASP.NETCoreD10.Models;
using lab3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab3.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-M7BTVHC\\SQLEXPRESS;Database=mvc_lab3;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString,
                options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothes" },
                new Category { Id = 3, Name = "Books" },
                new Category { Id = 4, Name = "Home Appliances" },
                new Category { Id = 5, Name = "Sports" },
                new Category { Id = 6, Name = "Accessories" }
            };

            var products = new List<Product>()
            {
                new Product { Id = 1,  Title = "Laptop",        Description = "Gaming Laptop",        Price = 15000, Count = 5,  CategoryId = 1, ExpiryDate = DateTime.Today.AddYears(2) },
                new Product { Id = 2,  Title = "Smartphone",    Description = "Android Smartphone",   Price = 9000,  Count = 10, CategoryId = 1, ExpiryDate = DateTime.Today.AddYears(1) },
                new Product { Id = 3,  Title = "Headphones",    Description = "Wireless Headphones",  Price = 1200,  Count = 15, CategoryId = 1, ExpiryDate = DateTime.Today.AddYears(1) },
                new Product { Id = 4,  Title = "T-Shirt",       Description = "Cotton T-Shirt",       Price = 300,   Count = 20, CategoryId = 2, ExpiryDate = DateTime.Today.AddYears(3) },
                new Product { Id = 5,  Title = "Jeans",         Description = "Blue Denim Jeans",     Price = 800,   Count = 12, CategoryId = 2, ExpiryDate = DateTime.Today.AddYears(3) },
                new Product { Id = 6,  Title = "Jacket",        Description = "Winter Jacket",        Price = 1500,  Count = 7,  CategoryId = 2, ExpiryDate = DateTime.Today.AddYears(3) },
                new Product { Id = 7,  Title = "C# Book",       Description = "Learn C# Programming", Price = 450,   Count = 25, CategoryId = 3, ExpiryDate = DateTime.Today.AddYears(5) },
                new Product { Id = 8,  Title = "ASP.NET Core Book", Description = "Master ASP.NET Core", Price = 550, Count = 18, CategoryId = 3, ExpiryDate = DateTime.Today.AddYears(5) },
                new Product { Id = 9,  Title = "Microwave",     Description = "800W Microwave Oven", Price = 3200,  Count = 6,  CategoryId = 4, ExpiryDate = DateTime.Today.AddYears(2) },
                new Product { Id = 10, Title = "Refrigerator",  Description = "Double Door Fridge",   Price = 12000, Count = 4,  CategoryId = 4, ExpiryDate = DateTime.Today.AddYears(3) },
                new Product { Id = 11, Title = "Football",      Description = "Professional Football", Price = 250,  Count = 30, CategoryId = 5, ExpiryDate = DateTime.Today.AddYears(1) },
                new Product { Id = 12, Title = "Tennis Racket", Description = "Carbon Fiber Racket",  Price = 1100,  Count = 9,  CategoryId = 5, ExpiryDate = DateTime.Today.AddYears(2) },
                new Product { Id = 13, Title = "Watch",         Description = "Digital Wrist Watch",  Price = 600,   Count = 14, CategoryId = 6, ExpiryDate = DateTime.Today.AddYears(3) },
                new Product { Id = 14, Title = "Backpack",      Description = "Laptop Backpack",      Price = 700,   Count = 16, CategoryId = 6, ExpiryDate = DateTime.Today.AddYears(4) }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}