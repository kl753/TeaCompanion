using TeaAPI.Infrastructure;

namespace TeaAPI.Services
{
    public interface IBrewLogService
    {
        Task<IEnumerable<BrewLogDTO>> GetBrewLogsForUserAsync(int userId); // Get all brew logs for a user
        Task<IEnumerable<BrewLogDTO>> GetBrewLogsForUserTeaStashAsync(int userTeaStashId, int userId); // Get all brew logs for a specific tea
        Task<BrewLogDTO?> GetBrewLogByIdAsync(int brewLogId, int userId); // Get a specific brew log by ID and user ID
        Task<BrewLogDTO?> CreateBrewLogAsync(int userId, CreateBrewLogDTO createDto); // Create a new brew log
        Task<BrewLogDTO?> UpdateBrewLogAsync(int brewLogId, int userId, UpdateBrewLogDTO updateDto); // Update an existing brew log
        Task<bool> DeleteBrewLogAsync(int brewLogId, int userId); // Delete a brew log by ID and user ID
    }
}
