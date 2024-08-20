using Microsoft.EntityFrameworkCore;
using XuongMayBE.Models;
namespace XuongMayBE.Data
{
    public class GarmentFactoryContext : DbContext
    {
        // Thư mục Data chỉ chứa Entity và Context
        //Class này tương ứng với DB
        public GarmentFactoryContext(DbContextOptions<GarmentFactoryContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
    #region Dbset

    #endregion
}
