using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;

namespace XuongMayBE.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly GarmentFactoryContext _context;

        public OrderDetailRepository(GarmentFactoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.Entry(orderDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> OrderDetailExistsAsync(int id)
        {
            return await _context.OrderDetails.AnyAsync(e => e.OrderDetailID == id);
        }
    }
}
