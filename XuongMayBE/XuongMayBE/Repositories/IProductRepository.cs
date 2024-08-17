using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public interface IProductRepository
    {
        //Lấy tất cả Product
        public Task<List<ProductModels>> GetAllProductAsync();
        //Lấy một Product
        public Task<ProductModels> GetProductByIdAsync(int id);
        //Thêm
        public Task<int> AddProductAsync(ProductModels productModel);
        // Sửa
        public Task UpdateProductAsync(int id, ProductModels productModel);
        //Xoá
        public Task DeleteProductAsync(int id);
    }
}
