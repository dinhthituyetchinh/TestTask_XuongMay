using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GarmentFactoryContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(GarmentFactoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryModels categoryModel)
        {
            // Chuyển đổi
            var newCategory = _mapper.Map<Category>(categoryModel);
            // Sau đó add lại
            _context.Categories!.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory.Id;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var deleteCategory = _context.Categories!.Where(x => x.Id == id).FirstOrDefault();
            if (deleteCategory != null)
            {
                _context.Categories!.Remove(deleteCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryModels>> getAllCategoryAsync()  
        {
            var categories = await _context.Categories!.ToListAsync();
            return _mapper.Map<List<CategoryModels>>(categories);
        }

        public async Task<CategoryModels> GetCategoryByIdAsync(int id)
        {
            // Lấy 1 danh mục
            var category = await _context.Categories!.FindAsync(id);
            return _mapper.Map<CategoryModels>(category);
        }

        public async Task UpdateCategoryAsync(int id, CategoryModels categoryModel)
        {
            if (id == categoryModel.Id)
            {
                var updateCategory = _mapper.Map<Category>(categoryModel);
                _context.Categories!.Update(updateCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
