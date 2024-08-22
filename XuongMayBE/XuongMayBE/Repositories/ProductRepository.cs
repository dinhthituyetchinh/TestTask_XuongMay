using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GarmentFactoryContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(GarmentFactoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddProductAsync(ProductModels productModel)
        {
            //Chuyển đổi 
            var newProduct = _mapper.Map<Product>(productModel);
            //Sau đó add lại
            _context.Products!.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteProd = _context.Products!.Where(x => x.Id == id).FirstOrDefault();
            if (deleteProd != null)
            {
                _context.Products!.Remove(deleteProd);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductModels>> GetAllProductAsync(int page)
        {
            //Lấy danh sách sản phẩm
            var product = await _context.Products!.Skip((page - 1) * 10).Take(10).ToListAsync();
            return _mapper.Map<List<ProductModels>>(product);
        }

        public async Task<ProductModels> GetProductByIdAsync(int id)
        {
            //Lấy 1 sản phẩm
            var product = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductModels>(product);
        }

        public async Task UpdateProductAsync(int id, ProductModels productModel)
        {
            if (id == productModel.Id)
            {
                var updateProduct = _mapper.Map<Product>(productModel);
                _context.Products!.Update(updateProduct);
                await _context.SaveChangesAsync();

            }
        }
    }
}