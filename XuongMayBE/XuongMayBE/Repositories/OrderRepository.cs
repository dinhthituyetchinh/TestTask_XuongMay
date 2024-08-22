using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GarmentFactoryContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(GarmentFactoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddOrderAsync(OrderModel orderModel)
        {
            var newOrder = _mapper.Map<Order>(orderModel);
            _context.Orders!.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder.Id;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var orderToDelete = _context.Orders!.Where(x => x.Id == id).FirstOrDefault();
            if (orderToDelete != null)
            {
                _context.Orders!.Remove(orderToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrderAsync()
        {
            var orders = await _context.Orders!.ToListAsync();
            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders!.FindAsync(id);
            return _mapper.Map<OrderModel>(order);
        }

        public async Task UpdateOrderAsync(int id, OrderModel orderModel)
        {
            if (id == orderModel.Id)
            {
                var updateOrder = _mapper.Map<Order>(orderModel);
                _context.Orders!.Update(updateOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}