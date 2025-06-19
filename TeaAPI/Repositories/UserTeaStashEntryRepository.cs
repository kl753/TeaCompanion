/*Layer abstracting data access logic.
 * Implementation of IUserTeaStashRepository interface
 */
using Microsoft.EntityFrameworkCore;
using TeaAPI.Data; // Assuming the AppDbContext is in the Data namespace
using TeaAPI.Models; // Assuming the Tea model is in the Models namespace

namespace TeaAPI.Repositories
{
    public class UserTeaStashEntryRepository : IUserTeaStashEntryRepository
    {
        private readonly AppDbContext _context;

        public UserTeaStashEntryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTeaStashEntry>> GetUserStashEntriesAsync(int userId)
        {
            return await _context.UserTeaStashEntries
                .Where(entry => entry.UserId == userId)
                .Include(entry => entry.Tea) // Include related Tea entity
                .ToListAsync();
        }

        public async Task<UserTeaStashEntry?> GetUserStashEntryByIdAsync(int id, int userId)
        {
            return await _context.UserTeaStashEntries
                .Include(entry => entry.Tea) // Include related Tea entity
                .FirstOrDefaultAsync(entry => entry.Id == id && entry.UserId == userId);
        }

        public async Task CreateUserStashEntryAsync(UserTeaStashEntry entry)
        {
            await _context.UserTeaStashEntries.AddAsync(entry);
            // SaveChangesAsync will be called by the service layer
        }

        public async Task UpdateUserStashEntryAsync(UserTeaStashEntry entry)
        {
            _context.UserTeaStashEntries.Update(entry);
            // SaveChangesAsync will be called by the service layer
        }

        public async Task DeleteUserStashEntryAsync(UserTeaStashEntry entry)
        {
            _context.UserTeaStashEntries.Remove(entry);
            // SaveChangesAsync will be called by the service layer
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0; // Returns true if any changes were saved to the database
        }
    }
}
