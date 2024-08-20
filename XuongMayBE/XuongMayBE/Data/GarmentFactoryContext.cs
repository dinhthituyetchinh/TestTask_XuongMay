using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XuongMayBE.Models;

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
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Users> Users { get; set; }
        #endregion

    }  
}
