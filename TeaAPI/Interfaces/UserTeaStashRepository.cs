using Microsoft.EntityFrameworkCore;
using TeaAPI.Models;
using TeaAPI.Models.Data;

namespace TeaAPI.Interfaces
{
    public class UserTeaStashRepository : IUserTeaStashRepository
    {
        private readonly ApplicationDbContext _context;

        public UserTeaStashRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTeaStash>> GetAllUserTeaStashesAsync(int userId)
        {
            return await _context.UserTeaStashes
                .Where(uts => uts.UserId == userId)
                .Include(uts => uts.Tea) // Include related Tea entity
                .ToListAsync();
        }

        public async Task<UserTeaStash?> GetUserTeaStashByIdAsync(int stashId, int userId)
        {
            return await _context.UserTeaStashes
                .Include(uts => uts.Tea) // Include related Tea entity
                .FirstOrDefaultAsync(uts => uts.Id == stashId && uts.UserId == userId);
        }

        public async Task CreateUserTeaStashAsync(UserTeaStash userTeaStash)
        {
            _context.UserTeaStashes.Add(userTeaStash);
        }

        public async Task UpdateUserTeaStashAsync(UserTeaStash userTeaStash)
        {
            _context.UserTeaStashes.Update(userTeaStash);
        }

        public async Task DeleteUserTeaStashAsync(UserTeaStash userTeaStash)
        {
            _context.UserTeaStashes.Remove(userTeaStash);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0; // Returns true if changes were saved
        }
}
