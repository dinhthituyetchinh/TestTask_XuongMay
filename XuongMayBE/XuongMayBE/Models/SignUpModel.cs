using System.ComponentModel.DataAnnotations;

namespace XuongMayBE.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, Phone]
        public string Phone { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        // Có thể thêm thuộc tính Role_ID nếu cần thiết trong quá trình đăng ký
        //public int? RoleId { get; set; }
    }
}
