/*Repository interface for Tea
 * Layer abstracting data access logic.
 * Interface for Tea repository
 */
using TeaAPI.Models; // Assuming the Tea model is in the Models namespace

namespace TeaAPI.Repositories
{
    public interface ITeaRepository
    {
        Task<IEnumerable<Tea>> GetAllTeasAsync(); // Get all teas
        Task<Tea?> GetTeaByIdAsync(int id); // Get tea by Id
        Task CreateTeaAsync(Tea tea); // Create a new tea
        Task UpdateTeaAsync(Tea tea); // Update an existing tea
        Task DeleteTeaAsync(Tea tea); // Delete a tea by Id
        Task<bool> SaveChangesAsync();
    }
}
