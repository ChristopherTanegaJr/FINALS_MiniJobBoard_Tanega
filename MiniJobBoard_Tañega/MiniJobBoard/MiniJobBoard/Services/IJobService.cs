using MiniJobBoard.Models;

namespace MiniJobBoard.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllAsync();
        Task<Job?> GetByIdAsync(int id);
        Task<Job> CreateAsync(Job job);
        Task<bool> UpdateAsync(Job job);
        Task<bool> DeleteAsync(int id);
    }
}
