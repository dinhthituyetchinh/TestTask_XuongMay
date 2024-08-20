using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
namespace XuongMayBE.Data
{
    public class GarmentFactoryContext : IdentityDbContext<ApplicationUser> 
    {
        // Thư mục Data chỉ chứa Entity và Context
        //Class này tương ứng với DB
        public GarmentFactoryContext(DbContextOptions<GarmentFactoryContext> option) : base(option)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
    #region Dbset

    #endregion
}
