using TeaAPI.Models;

namespace TeaAPI.Interfaces
{
    public interface IUserTeaStashRepository
    {
        Task<IEnumerable<UserTeaStash>> GetUserTeaStashesAsync(int userId); // Get all tea stashes for a user
        Task<UserTeaStash?> GetUserTeaStashByIdAsync(int teaId, int userId); // Get a specific tea stash by user ID and tea ID
        Task CreateUserTeaStashAsync(UserTeaStash stashItem);
        Task UpdateUserTeaStashAsync(UserTeaStash stashItem);
        Task DeleteUserTeaStashAsync(UserTeaStash stashItem);
        Task<bool> SaveChangesAsync(); // For unit of work pattern
    }
}
