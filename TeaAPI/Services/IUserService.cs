/*Service layer interface
 * Layer for abstracting business logic.
 * Orchestrates calls to repository methods.
 * Helps decouple controllers from data access logic.
 * Interface for User service.
 */
using TeaAPI.DTOs;

namespace TeaAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(); //Get all users
        Task<UserDto?> GetUserByIdAsync(int id); //Get user by ID
        Task<UserDto?> GetUserByUsernameAsync(string username); //Get user by username
        Task<UserDto?> GetUserByEmailAsync(string email); //Get user by email
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto); //Create a new user
        Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto updateUserDto); //Update user information
        Task<bool> DeleteUserAsync(int id); //Delete user by ID
    }
}
