using XuongMayBE.Data;

namespace XuongMayBE.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tasks>> GetAllAsync();
        Task<Tasks> GetByIdAsync(int id);
        Task AddAsync(Tasks task);
        Task UpdateAsync(Tasks task);
        Task DeleteAsync(int id);
    }
}
