using Microsoft.EntityFrameworkCore;
using TeaAPI.Models.Data;
using TeaAPI.Models;

namespace TeaAPI.Interfaces
{
    public class BrewLogRepository : IBrewLogRepository
    {
        private readonly ApplicationDbContext _context;

        public BrewLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrewLog>> GetAllBrewLogsForUserAsync(int userId)
        {
            return await _context.BrewLogs
                .Where(bl => bl.UserId == userId)
                .Include(bl => bl.UserTeaStash)
                    .ThenInclude(uts => uts.Tea)
                .ToListAsync();
        }

        public async Task<IEnumerable<BrewLog>> GetBrewLogsForUserTeaStashAsync(int userTeaStashId, int userId)
        {
            return await _context.BrewLogs
                .Where(bl => bl.UserTeaStashId == userTeaStashId && bl.UserId == userId)
                .Include(bl => bl.UserTeaStash)
                    .ThenInclude(uts => uts.Tea)
                .ToListAsync();
        }

        public async Task<BrewLog?> GetBrewLogByIdAsync(int brewLogId, int userId)
        {
            return await _context.BrewLogs
                .Include(bl => bl.UserTeaStash)
                    .ThenInclude(uts => uts.Tea)
                .FirstOrDefaultAsync(bl => bl.Id == brewLogId);
        }

        public async Task CreateBrewLogAsync(BrewLog brewLog)
        {
            _context.BrewLogs.Add(brewLog);
        }
        
        public async Task UpdateBrewLogAsync(BrewLog brewLog)
        {
            _context.BrewLogs.Update(brewLog);
        }

        public async Task DeleteBrewLogAsync(BrewLog brewLog)
        {
            _context.BrewLogs.Remove(brewLog);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0; // Returns true if changes were saved
        }
}
