using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using XuongMayBE.Data;

namespace XuongMayBE.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; private set; }

        public DateTime ModifyTime { get; private set; }

        public string RoleID { get; set; }

        public Users()
        {
            CreateTime = DateTime.Now;
            ModifyTime = CreateTime;
        }
        public static Users GetUserByUsername(GarmentFactoryContext context, string username)
        {
            // Lấy thông tin người dùng từ SQL
            return context.Users.FirstOrDefault(u => u.UserName == username);
        }
    }
}
