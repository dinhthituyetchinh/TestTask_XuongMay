using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using XuongMayBE.Data;
using XuongMayBE.Repositories;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    // GET: api/OrderDetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
    {
        var orderDetails = await _orderDetailRepository.GetAllOrderDetailsAsync();
        return Ok(orderDetails);
    }

    // GET: api/OrderDetails/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
    {
        var orderDetail = await _orderDetailRepository.GetOrderDetailByIdAsync(id);

        if (orderDetail == null)
        {
            return NotFound();
        }

        return Ok(orderDetail);
    }

    // POST: api/OrderDetails
    [HttpPost]
    public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
    {
        await _orderDetailRepository.AddOrderDetailAsync(orderDetail);
        return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.OrderDetailID }, orderDetail);
    }

    // PUT: api/OrderDetails/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
    {
        if (id != orderDetail.OrderDetailID)
        {
            return BadRequest();
        }

        await _orderDetailRepository.UpdateOrderDetailAsync(orderDetail);

        try
        {
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _orderDetailRepository.OrderDetailExistsAsync(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }

    // DELETE: api/OrderDetails/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        if (!await _orderDetailRepository.OrderDetailExistsAsync(id))
        {
            return NotFound();
        }

        await _orderDetailRepository.DeleteOrderDetailAsync(id);
        return NoContent();
    }
}
