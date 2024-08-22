using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Models;
using XuongMayBE.Repositories;

namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                return Ok(await _categoryRepository.getAllCategoryAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(CategoryModels categoryModel)
        {
            try
            {
                var newCategoryId = await _categoryRepository.AddCategoryAsync(categoryModel);
                return CreatedAtAction(nameof(GetCategoryById), new { id = newCategoryId }, newCategoryId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryModels categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return NotFound();
            }
            await _categoryRepository.UpdateCategoryAsync(id, categoryModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
