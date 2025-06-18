using TeaAPI.Infrastructure;

namespace TeaAPI.Services
{
    public interface IUserTeaStashService
    {
        Task<IEnumerable<UserTeaStashDTO>> GetUserTeaStashAsync(int userId);
        Task<UserTeaStashDTO?> GetUserTeaStashItemAsync(int stashId, int userId);
        Task<UserTeaStashDTO?> CreateTeaToStashAsync(int userId, CreateUserTeaStashDTO createUserTeaStashDTO);
        Task<UserTeaStashDTO?> UpdateTeaInStashAsync(int stashId, int userId, UpdateUserTeaStashDTO updateDTO);
        Task<bool> DeleteTeaFromStashAsync(int stashId, int userId);
    }
}
