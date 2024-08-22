using XuongMayBE.Data;

namespace XuongMayBE.Repositories
{
    public interface IProductionLineRepository
    {
        Task<IEnumerable<ProductionLine>> GetAllAsync();
        Task<ProductionLine> GetByIdAsync(int id);
        Task AddAsync(ProductionLine productionLine);
        Task UpdateAsync(ProductionLine productionLine);
        Task DeleteAsync(int id);
    }

}
