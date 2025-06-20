/*Layer abstracting data access logic.
 * Implementation of IBrewSessionRepository interface
 */
using Microsoft.EntityFrameworkCore;
using TeaAPI.Data; // Assuming the AppDbContext is in the Data namespace
using TeaAPI.Models; // Assuming the Tea model is in the Models namespace

namespace TeaAPI.Repositories
{
    public class BrewSessionRepository : IBrewSessionRepository
    {
        private readonly AppDbContext _context;
        
        public BrewSessionRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<BrewSession>> GetBrewSessionsForUserAsync(int userId)
        {
            return await _context.BrewSessions
                .Where(bs => bs.UserId == userId)
                .Include(bs => bs.Tea) // Include related Tea entity
                .ToListAsync();
        }
        
        public async Task<BrewSession?> GetBrewSessionByIdAsync(int id, int userId)
        {
            return await _context.BrewSessions
                .Include(bs => bs.Tea) // Include related Tea entity
                .FirstOrDefaultAsync(bs => bs.Id == id && bs.UserId == userId);
        }
        
        public async Task<BrewSession> CreateBrewSessionAsync(BrewSession session)
        {
            _context.BrewSessions.Add(session);
        }
        
        public async Task<BrewSession?> UpdateBrewSessionAsync(BrewSession session)
        {
            _context.BrewSessions.Update(session);
        }
        
        public async Task DeleteBrewSessionAsync(BrewSession session)
        {
            _context.BrewSessions.Remove(session);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
