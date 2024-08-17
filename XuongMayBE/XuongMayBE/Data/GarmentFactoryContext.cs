using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;
namespace XuongMayBE.Data
{
    public class GarmentFactoryContext : DbContext
    {
        // Thư mục Data chỉ chứa Entity và Context
        //Class này tương ứng với DB
        public GarmentFactoryContext(DbContextOptions<GarmentFactoryContext> option) : base(option)
        {

        }
        // Thư mục Data chỉ chứa Entity và Context
        //Class này tương ứng với DB
        public DbSet<XuongMayBE.Data.Product>? Product { get; set; }
    }
    #region Dbset

    #endregion
}
