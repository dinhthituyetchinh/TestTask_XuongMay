
using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModels>> getAllCategoryAsync();
        Task<CategoryModels> GetCategoryByIdAsync(int id);
        //Thêm
        Task<int> AddCategoryAsync(CategoryModels categoryModels);
        // Sửa
        Task UpdateCategoryAsync(int id, CategoryModels categoryModels);
        //Xoá
        Task DeleteCategoryAsync(int id);
    }
}
