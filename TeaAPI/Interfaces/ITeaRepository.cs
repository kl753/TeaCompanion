//Layer abstracts for data access logic
using TeaAPI.Models;

namespace TeaAPI.Interfaces
{
    public interface ITeaRepository
    {
        Task<IEnumerable<Tea>> GetAllTeasAsync(); //Get all teas
        Task<Tea?> GetTeaByIdAsync(int id); //Get tea by ID
        Task<Tea> CreateTeaAsync(Tea tea); //Create a new tea
        Task<Tea?> UpdateTeaAsync(int id, Tea tea); //Update an existing tea
        Task<bool> DeleteTeaAsync(int id); //Delete a tea by ID
        Task<bool> SaveChangesAsync(); //For unit of work pattern
        Task UpdateTeaAsync(Tea existingTea);
        Task DeleteTeaAsync(Tea teaToDelete);
    }
}
