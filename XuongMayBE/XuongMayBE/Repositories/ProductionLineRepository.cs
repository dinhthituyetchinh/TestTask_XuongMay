using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;

namespace XuongMayBE.Repositories
{
    public class ProductionLineRepository : IProductionLineRepository
    {
        private readonly GarmentFactoryContext _context;

        public ProductionLineRepository(GarmentFactoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductionLine>> GetAllAsync()
        {
            return await _context.ProductionLines.Include(pl => pl.Tasks).ToListAsync();
        }

        public async Task<ProductionLine> GetByIdAsync(int id)
        {
            return await _context.ProductionLines.Include(pl => pl.Tasks)
                                                 .FirstOrDefaultAsync(pl => pl.LineID == id);
        }

        public async Task AddAsync(ProductionLine productionLine)
        {
            await _context.ProductionLines.AddAsync(productionLine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductionLine productionLine)
        {
            _context.ProductionLines.Update(productionLine);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productionLine = await GetByIdAsync(id);
            if (productionLine != null)
            {
                _context.ProductionLines.Remove(productionLine);
                await _context.SaveChangesAsync();
            }
        }
    }
}
