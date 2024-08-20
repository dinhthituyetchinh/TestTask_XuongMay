using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public interface IProductRepository
    {
        //Lấy tất cả Product
        Task<List<ProductModels>> GetAllProductAsync();
        //Lấy một Product
        Task<ProductModels> GetProductByIdAsync(int id);
        //Thêm
        Task<int> AddProductAsync(ProductModels productModel);
        // Sửa
        Task UpdateProductAsync(int id, ProductModels productModel);
        //Xoá
        Task DeleteProductAsync(int id);
    }
}
