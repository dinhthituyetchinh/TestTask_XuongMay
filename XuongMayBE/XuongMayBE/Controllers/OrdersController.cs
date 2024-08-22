using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Models;
using XuongMayBE.Repositories;
using XuongMayBE.Attribute;


namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Anthorization("Admin")]

    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await _orderRepository.GetAllOrderAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrder(OrderModel orderModel)
        {
            try
            {
                var newOrderId = await _orderRepository.AddOrderAsync(orderModel);
                return CreatedAtAction(nameof(GetOrderById), new { id = newOrderId }, newOrderId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderModel orderModel)
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }
            await _orderRepository.UpdateOrderAsync(id, orderModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return Ok();
        }
    }
}