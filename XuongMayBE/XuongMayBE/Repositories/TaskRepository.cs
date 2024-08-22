using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;

namespace XuongMayBE.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly GarmentFactoryContext _context;

        public TaskRepository(GarmentFactoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllAsync()
        {
            return await _context.Tasks.Include(t => t.ProductionLine).ToListAsync();
        }

        public async Task<Tasks> GetByIdAsync(int id)
        {
            return await _context.Tasks.Include(t => t.ProductionLine)
                                       .FirstOrDefaultAsync(t => t.TaskID == id);
        }

        public async Task AddAsync(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
