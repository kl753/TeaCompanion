/*Repository interface for User
 * Layer for abstracting data access logic.
 * Interface for User repository.
 */
using TeaAPI.Models; 

namespace TeaAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(); //Get all users
        Task<User?> GetUserByIdAsync(int id); //Get user by ID
        Task<User?> GetUserByUserameAsync(string username); //Get user by username
        Task<User?> GetUserByEmailAsync(string email); //Get user by email
        Task CreateUserAsync(User user); //Create a new user
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user); //Delete user by ID
        Task<bool> SaveChangesAsync(); //Save changes to the database
    }
}
