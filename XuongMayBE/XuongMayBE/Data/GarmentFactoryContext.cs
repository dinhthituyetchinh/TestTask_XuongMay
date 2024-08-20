using Microsoft.EntityFrameworkCore;
namespace XuongMayBE.Data
{
    public class GarmentFactoryContext : DbContext
    {
        public GarmentFactoryContext(DbContextOptions<GarmentFactoryContext> option) : base(option)
        {

        }

        #region Dbset
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        #endregion

    }

}
