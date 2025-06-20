/*Repository interface for bew session data access logic.
 * Layer abstracting data access logic.
 * Interface for brew session repository
 */
using TeaAPI.Models;

namespace TeaAPI.Repositories
{
    public interface IBrewSessionRepository
    {
        Task<IEnumerable<BrewSession>> GetAllBrewSessionsForUserAsync(int userId); // Get all brew sessions for a user
        Task<BrewSession?> GetBrewSessionByIdAsync(int id, int userId); // Get a specific brew session by ID
        Task<BrewSession> CreateBrewSessionAsync(BrewSession session); // Create a new brew session
        Task<BrewSession?> UpdateBrewSessionAsync(BrewSession session); // Update an existing brew session
        Task<bool> DeleteBrewSessionAsync(BrewSession session); // Delete a brew session by ID
        Task<bool> SaveChangesAsync(); // Save changes to the database
    }
}
