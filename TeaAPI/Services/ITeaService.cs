//Interface for Tea Service
using TeaAPI.Infrastructure;

namespace TeaAPI.Services
{
    public interface ITeaService
    {
        Task<IEnumerable<TeaDTO>> GetAllTeasAsync(); //Get all teas
        Task<TeaDTO?> GetTeaByIdAsync(int id); //Get tea by ID
        Task<TeaDTO> CreateTeaAsync(CreateTeaDTO CreateTeaDto); //Create a new tea
        Task<TeaDTO?> UpdateTeaAsync(int id, UpdateTeaDTO updateTeaDto); //Update an existing tea
        Task<bool> DeleteTeaAsync(int id); //Delete a tea by ID
    }
}
