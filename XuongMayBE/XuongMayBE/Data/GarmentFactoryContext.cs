using Microsoft.EntityFrameworkCore;
namespace XuongMayBE.Data
{
    public class GarmentFactoryContext : DbContext
    {
        // Thư mục Data chỉ chứa Entity và Context
        //Class này tương ứng với DB
        public GarmentFactoryContext(DbContextOptions<GarmentFactoryContext> option) : base(option)
        {

        }
    }
    #region Dbset

    #endregion
}
