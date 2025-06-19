/*Service layer interface
 * Layer for abstracting business logic.
 * Orchestrates calls to repository methods.
 * Helps decouple controllers from data access logic.
 * Interface for UserTeaStash service.
 */
using TeaAPI.DTOs;

namespace TeaAPI.Services
{
    public interface IUserTeaStashService
    {
        Task<IEnumerable<UserTeaStashEntryDto>> GetStashEntriesForUserAsync(int userId); //Get all tea stashes for a user
        Task<UserTeaStashEntryDto?> GetStashEntryByIdAsync(int entryId, int userId); //Get tea stash by ID for a user
        Task<UserTeaStashEntryDto> CreateTeaStashAsync(int userId, CreateUserTeaStashEntryDto createUserTeaStashEntryDto); //Create a new tea stash for a user
        Task<UserTeaStashEntryDto?> UpdateStashEntryAsync(int entryId, int userId, UpdateUserTeaStashEntryDto updateUserTeaStashEntryDto); //Update tea stash information for a user
        Task<bool> DeleteStashEntryAsync(int entryId, int userId); //Delete tea stash by ID for a user
    }
}
