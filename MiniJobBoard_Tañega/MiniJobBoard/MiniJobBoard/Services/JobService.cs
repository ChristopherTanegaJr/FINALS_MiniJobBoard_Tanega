using Microsoft.EntityFrameworkCore;
using MiniJobBoard.Infrastructure;
using MiniJobBoard.Models;

namespace MiniJobBoard.Services
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _db;

        public JobService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Job> CreateAsync(Job job)
        {
            _db.Jobs.Add(job);
            await _db.SaveChangesAsync();
            return job;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var j = await _db.Jobs.FindAsync(id);
            if (j == null) return false;
            _db.Jobs.Remove(j);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _db.Jobs.OrderByDescending(j => j.PostedOn).ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            return await _db.Jobs.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Job job)
        {
            var exists = await _db.Jobs.AnyAsync(j => j.Id == job.Id);
            if (!exists) return false;
            _db.Jobs.Update(job);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
