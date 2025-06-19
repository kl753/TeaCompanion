/*Layer abstracting data access logic.
 * Implementation of IUserRepository repository.
 */
using Microsoft.EntityFrameworkCore;
using TeaAPI.Models;
using TeaAPI.Data;

namespace TeaAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        
        public async Task<User?> GetUserByUserameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        
        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            //SaveChangesAsync is called by service layer
        }
        
        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            //SaveChangesAsync is called by service layer
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0; // Returns true if any changes were saved
        }
    }
}
