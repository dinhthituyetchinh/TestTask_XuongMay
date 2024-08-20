using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace XuongMayBE.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
