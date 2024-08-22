using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Attribute;
using XuongMayBE.Models;
using XuongMayBE.Repositories;


namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
    [Anthorization("Admin")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Anthorization("User")]
        public async Task<IActionResult> GetAllProducts(int page)
        {
            try
            {

                return Ok(await _productRepository.GetAllProductAsync(page));

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> getProductByID(int id)
        {
            var p = await _productRepository.GetProductByIdAsync(id);
            return p == null ? NotFound() : Ok(p);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModels productModels)
        {
            try
            {
                var newProdID = await _productRepository.AddProductAsync(productModels);
                return CreatedAtAction(nameof(getProductByID), new { controller = "Products", newProdID }, newProdID);
                ////Cách 2:
                //var p = await _productRepository.GetProductByIdAsync(newProdID);
                //return p == null ? NotFound() : Ok(p);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductModels productModels)
        {
            if (id != productModels.Id)
            {
                return NotFound();
            }
            await _productRepository.UpdateProductAsync(id, productModels);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {

            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
    }
}