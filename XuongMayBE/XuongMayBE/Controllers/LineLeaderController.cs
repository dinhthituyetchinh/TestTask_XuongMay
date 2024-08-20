using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Attribute;

namespace XuongMayBE.Controllers
{
    public class OrderController : ControllerBase
    {
        [HttpGet("line-leader-only")]
        [Anthorization("Line Leader")]
        public IActionResult LineLeaderOnlyAction()
        {
            return Ok("This is a Line Leader-only action.");
        }

    }
}

