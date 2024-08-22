using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api;
using XuongMayBE.Attribute;
using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
    [Anthorization("Admin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GarmentFactoryContext garmentFactoryContext;
        public UsersController(GarmentFactoryContext garmentFactoryContext)
        {
            this.garmentFactoryContext = garmentFactoryContext;
        }
        [HttpGet()]
        [Route("GetUsers")]
        public List<Models.Users> GetUsers()
        {
            return garmentFactoryContext.Users.ToList();
        }
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] Models.Users newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User object cannot be null");
            }

            try
            {
                garmentFactoryContext.Users.Add(newUser);
                garmentFactoryContext.SaveChanges();
                return CreatedAtAction("GetUsers", new { id = newUser.UserID }, newUser);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về mã trạng thái HTTP thích hợp
                return StatusCode(500, $"An error occurred while creating the user: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Models.Users updatedUser)
        {
            var user = garmentFactoryContext.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Cập nhật các thuộc tính của đối tượng user
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Phone = updatedUser.Phone;
            user.Password = updatedUser.Password;
            user.Role = updatedUser.Role;

            garmentFactoryContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            garmentFactoryContext.SaveChanges();
            return Ok("User Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = garmentFactoryContext.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            garmentFactoryContext.Users.Remove(user);
            garmentFactoryContext.SaveChanges();
            return Ok("User Deleted");
        }
    }
}