/*Service layer interface for authentication services.
 */
using TeaAPI.Models;
using TeaAPI.DTOs;

namespace TeaAPI.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDto loginDto);
        string GenerateJwtToken(User user);
    }
}
