using Microsoft.Extensions.Configuration;
using XuongMayBE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Users> Users { get; set; }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Ensure Identity configuration is applied

            builder.Entity<Order>().HasData(
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
    }
}
