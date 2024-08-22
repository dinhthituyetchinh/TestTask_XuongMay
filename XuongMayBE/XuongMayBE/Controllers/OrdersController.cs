using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMayBE.Attribute;
using XuongMayBE.Data;
using XuongMayBE.Service;

namespace XuongMayBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Anthorization("Admin")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]

        [Anthorization("Line Leader")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]

        [Anthorization("Line Leader")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _orderService.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderID }, order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            if (!await _orderService.OrderExistsAsync(id))
            {
                return NotFound();
            }

            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (!await _orderService.OrderExistsAsync(id))
            {
                return NotFound();
            }

            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
