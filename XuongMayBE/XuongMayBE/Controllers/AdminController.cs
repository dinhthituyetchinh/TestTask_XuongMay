using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Attribute;

namespace XuongMayBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        [HttpGet("admin-only")]
        [Anthorization("Admin")]
        public IActionResult AdminOnlyAction()
        {
            return Ok("This is an admin-only action.");
        }
    }

}
