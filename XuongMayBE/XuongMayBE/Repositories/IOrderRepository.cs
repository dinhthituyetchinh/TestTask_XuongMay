using Microsoft.Graph.Models;
using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public interface IOrderRepository
    {
        //Lấy tất cả Product
        Task<IEnumerable<OrderModel>> GetAllOrderAsync();
        //Lấy một Product
        Task<OrderModel> GetOrderByIdAsync(int id);
        //Thêm
        Task<int> AddOrderAsync(OrderModel productModel);
        // Sửa
        Task UpdateOrderAsync(int id, OrderModel productModel);
        //Xoá
        Task DeleteOrderAsync(int id);
    }
}