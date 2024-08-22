using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using XuongMayBE.Models;
using XuongMayBE.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using XuongMayBE.Data;

[ApiController]
[Route("api/[controller]")]
public class UserAuthorizationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly Users _user;
    private readonly GarmentFactoryContext _context;

    public UserAuthorizationController(IConfiguration configuration, Users user, GarmentFactoryContext context)
    {
        _configuration = configuration;
        _user = user;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserRequestModel userRequestModel)
    {
        // Lấy thông tin người dùng từ SQL dựa trên username
        var user = Users.GetUserByUsername(_context, userRequestModel.UserName);

        // Kiểm tra thông tin đăng nhập từ cơ sở dữ liệu hoặc dịch vụ xác thực
        if (user == null || !VerifyPassword(user, userRequestModel.Password))
        {
            return Unauthorized("Invalid credentials");
        }

        // Lấy các giá trị từ cấu hình
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];

        // Gán vai trò cho người dùng dựa trên thông tin đăng nhập
        var role = user.RoleID == "Admin" ? "Admin" : "Line Leader";

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userRequestModel.UserName),
            new Claim(ClaimTypes.Role, role),
            new Claim("FullName", "Tran Quyet Tai"),
        };

        var keyBytes = Encoding.ASCII.GetBytes(key);
        var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { Token = tokenString });
    }

    private bool VerifyPassword(Users user, string password)
    {
        // Thực hiện kiểm tra mật khẩu ở đây, ví dụ:
        return user.Password == password;
    }
}
