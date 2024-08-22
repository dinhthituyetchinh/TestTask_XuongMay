using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
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
        public List<Users> GetUsers()
        {
            return garmentFactoryContext.Users.ToList();
        }
        [HttpPost]
        [Route("CreateUser")]
        public string CreateUser(Users users)
        {
            
            garmentFactoryContext.Users.Add(users);
            garmentFactoryContext.SaveChanges();
            return "User Created";
        }
        [HttpPost]
        [Route("UpdateUser")]
        public string UpdateUser(Users user)
        {
            garmentFactoryContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            garmentFactoryContext.SaveChanges();
            return "User Updated";
        }
        [HttpPost]
        [Route("DeleteUser")]
        public string DeleteUser(Users user)
        {
            garmentFactoryContext.Users.Remove(user);
            garmentFactoryContext.SaveChanges();
            return "User Deleted";
        }
    }
}
