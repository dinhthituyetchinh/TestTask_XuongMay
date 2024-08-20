using XuongMayBE.Data;

namespace XuongMayBE.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail> GetOrderDetailByIdAsync(int id);
        Task AddOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int id);
        Task<bool> OrderDetailExistsAsync(int id);
    }
}
