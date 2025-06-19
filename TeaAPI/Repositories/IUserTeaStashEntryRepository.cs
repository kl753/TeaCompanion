/*Repository interface for UserTeaStashEntry
 * Layer abstracting data access logic.
 */
using TeaAPI.Models; // Assuming the models are in the Models namespace

namespace TeaAPI.Repositories
{
    public interface IUserTeaStashEntryRepository
    {
        Task<IEnumerable<UserTeaStashEntry>> GetUserStashEntriesAsync(int userId);
        Task<UserTeaStashEntry?> GetUserStashEntryByIdAsync(int id, int userId);
        Task CreateUserStashEntryAsync(UserTeaStashEntry entry);
        Task UpdateUserStashEntryAsync(UserTeaStashEntry entry);
        Task DeleteUserStashEntryAsync(int id, int userId);
        Task<bool> SaveChangesAsync();
    }
}
