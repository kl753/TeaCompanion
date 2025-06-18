/*Service layer interface
 * Layer abstracting business logic
 * Orchestrates calls to the repository layer.
 * Helps decouple controller from database access logic.
 * Interface for Tea service
 */
using TeaAPI.DTOs; // Assuming DTOs are in the DTOs namespace

namespace TeaAPI.Services
{
    public interface ITeaService
    {
        Task<IEnumerable<TeaDto>> GetAllTeasAsync(); // Get all teas
        Task<TeaDto?> GetTeaByIdAsync(int id); // Get tea by Id
        Task<TeaDto> CreateTeaAsync(CreateTeaDto createTeaDto); // Create a new tea
        Task<TeaDto?> UpdateTeaAsync(int id, UpdateTeaDto updateTeaDto); // Update an existing tea
        Task DeleteTeaAsync(int id); // Delete a tea by Id
    }
}
