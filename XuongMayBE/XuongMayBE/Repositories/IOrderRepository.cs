using Microsoft.Graph.Models;
using XuongMayBE.Data;

namespace XuongMayBE.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
        Task<bool> OrderExistsAsync(int id);
    }
}
