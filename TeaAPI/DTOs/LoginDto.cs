/*Transfer data class for login
 * Used for POST requests to create a login
 */
using System.ComponentModel.DataAnnotations;

namespace TeaAPI.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; }
    }
}
