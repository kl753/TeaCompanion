using TeaAPI.Models;

namespace TeaAPI.Interfaces
{
    public interface IBrewLogRepository
    {
        Task<IEnumerable<BrewLog>> GetAllBrewLogsForUserAsync(int userId); // Get all brew logs
        Task<IEnumerable<BrewLog>> GetBrewLogsForUserTeaStashAsync(int userTeaStashId, int userId);
        Task<BrewLog?> GetBrewLogByIdAsync(int brewLogId, int userId); // Get brew log by ID
        Task CreateBrewLogAsync(BrewLog brewLog); // Create a new brew log
        Task UpdateBrewLogAsync(BrewLog brewLog); // Update an existing brew log
        Task DeleteBrewLogAsync(int id); // Delete a brew log by ID
        Task<bool> SaveChangesAsync(); // For unit of work pattern
    }
}
