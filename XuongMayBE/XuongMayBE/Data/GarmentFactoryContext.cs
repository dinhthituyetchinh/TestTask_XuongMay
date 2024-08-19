using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace XuongMayBE.Data
{
    public class GarmentFactoryContext : IdentityDbContext<ApplicationUser> 
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
