/*Transfer data class for updating an existing user.
 * Used for PUT requests to update user information.
 */
using System.ComponentModel.DataAnnotations;

namespace TeaAPI.DTOs
{
    public class UpdateUserDto
    {
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string? Username { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
        public string? Email { get; set; }

        //Password is not included in update DTO
        //Seperate "ChangePasswordDto" for that purpose.
    }
}
