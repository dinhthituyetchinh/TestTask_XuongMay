using Microsoft.Extensions.Configuration;
using XuongMayBE.Models;
﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
namespace XuongMayBE.Data
{

    public class GarmentFactoryContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public GarmentFactoryContext(DbContextOptions<GarmentFactoryContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Lấy chuỗi kết nối từ appsettings.json
                var connectionString = _configuration.GetConnectionString("GarmentFactory");

                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: 5, // Số lần thử lại tối đa
                        maxRetryDelay: TimeSpan.FromSeconds(10), // Thời gian chờ giữa các lần thử lại
                        errorNumbersToAdd: null // Các mã lỗi cụ thể sẽ kích hoạt thử lại (có thể để null)
                    );
                });
            }
        }


        #region Dbset
        public DbSet<Product> ?Products { get; set; }
        public DbSet<Category> ?Categories { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // tao productionline va tasks:
            modelBuilder.Entity<ProductionLine>(entity =>
            {
                entity.HasKey(e => e.LineID);
                entity.Property(e => e.LineName).IsRequired();
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskID);
                entity.Property(e => e.TaskName).IsRequired();
                entity.HasOne(d => d.ProductionLine)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(d => d.LineID);
            });

            // Seed data for Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothing" },
                new Category { Id = 2, Name = "Accessories" }
            );

            // Seed data for Product
            modelBuilder.Entity<Product>().HasData(
    new Product { Id = 1, Name = "T-Shirt", Description = "Cotton T-Shirt", Price = 19.99, Quantity = 50, CategoryID = 1 },
    new Product { Id = 2, Name = "Jeans", Description = "Denim Jeans", Price = 49.99, Quantity = 30, CategoryID = 1 },
    new Product { Id = 3, Name = "Hat", Description = "Baseball Cap", Price = 15.99, Quantity = 100, CategoryID = 2 },
    new Product { Id = 4, Name = "Jacket", Description = "Leather Jacket", Price = 89.99, Quantity = 20, CategoryID = 1 },
    new Product { Id = 5, Name = "Socks", Description = "Woolen Socks", Price = 5.99, Quantity = 150, CategoryID = 1 },
    new Product { Id = 6, Name = "Scarf", Description = "Silk Scarf", Price = 25.99, Quantity = 80, CategoryID = 2 },
    new Product { Id = 7, Name = "Gloves", Description = "Winter Gloves", Price = 12.99, Quantity = 70, CategoryID = 2 },
    new Product { Id = 8, Name = "Sweater", Description = "Woolen Sweater", Price = 35.99, Quantity = 40, CategoryID = 1 },
    new Product { Id = 9, Name = "Belt", Description = "Leather Belt", Price = 29.99, Quantity = 60, CategoryID = 2 },
    new Product { Id = 10, Name = "Shoes", Description = "Running Shoes", Price = 59.99, Quantity = 25, CategoryID = 2 },
    new Product { Id = 11, Name = "Shorts", Description = "Casual Shorts", Price = 19.99, Quantity = 90, CategoryID = 1 },
    new Product { Id = 12, Name = "Cap", Description = "Snapback Cap", Price = 15.99, Quantity = 110, CategoryID = 2 },
    new Product { Id = 13, Name = "Dress", Description = "Evening Dress", Price = 99.99, Quantity = 15, CategoryID = 1 },
    new Product { Id = 14, Name = "Blouse", Description = "Silk Blouse", Price = 39.99, Quantity = 50, CategoryID = 1 },
    new Product { Id = 15, Name = "Watch", Description = "Analog Watch", Price = 199.99, Quantity = 10, CategoryID = 2 },
    new Product { Id = 16, Name = "Sunglasses", Description = "Polarized Sunglasses", Price = 49.99, Quantity = 60, CategoryID = 2 },
    new Product { Id = 17, Name = "Tie", Description = "Silk Tie", Price = 25.99, Quantity = 100, CategoryID = 2 },
    new Product { Id = 18, Name = "Backpack", Description = "Travel Backpack", Price = 79.99, Quantity = 20, CategoryID = 2 },
    new Product { Id = 19, Name = "Suit", Description = "Business Suit", Price = 249.99, Quantity = 15, CategoryID = 1 },
    new Product { Id = 20, Name = "Polo Shirt", Description = "Cotton Polo Shirt", Price = 29.99, Quantity = 40, CategoryID = 1 },
    new Product { Id = 21, Name = "Sneakers", Description = "Casual Sneakers", Price = 69.99, Quantity = 30, CategoryID = 2 },
    new Product { Id = 22, Name = "Joggers", Description = "Cotton Joggers", Price = 39.99, Quantity = 70, CategoryID = 1 },
    new Product { Id = 23, Name = "Wallet", Description = "Leather Wallet", Price = 39.99, Quantity = 80, CategoryID = 2 },
    new Product { Id = 24, Name = "Sandals", Description = "Beach Sandals", Price = 19.99, Quantity = 50, CategoryID = 2 },
    new Product { Id = 25, Name = "Beanie", Description = "Winter Beanie", Price = 12.99, Quantity = 100, CategoryID = 2 }
);
            modelBuilder.Entity<Order>().HasData(
               new Order
               {
                   Id = 1,
                   OrderName = "Order 1",
                   OrderDate = new DateTime(2024, 8, 22),
                   Price = 99.99m,
                   Quantity = 10,
                   ProductID = 101
               },
               new Order
               {
                   Id = 2,
                   OrderName = "Order 2",
                   OrderDate = new DateTime(2024, 8, 23),
                   Price = 149.50m,
                   Quantity = 5,
                   ProductID = 102
               },
               new Order
               {
                   Id = 3,
                   OrderName = "Order 3",
                   OrderDate = new DateTime(2024, 8, 24),
                   Price = 299.99m,
                   Quantity = 2,
                   ProductID = 103
               }
           );

        }
        
        public DbSet<Models.Users> ?Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

    }    
}
