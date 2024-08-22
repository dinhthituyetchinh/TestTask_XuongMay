using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using XuongMayBE.Data;

namespace XuongMayBE.Models
{
    public class Users : IdentityUser
    {
        [Key]
        public int UserID { get; set; }

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; private set; }

        public DateTime ModifyTime { get; private set; }

        public string Role { get; set; }
        public void SetRole(string role)
        {
            Role = role;
        }
        public Users()
        {
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
        }
        public static Users GetUserByEmail(GarmentFactoryContext context, string email)
        {
            // Lấy thông tin người dùng từ SQL
            return context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}