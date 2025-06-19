/*Represents User table in the database.
 * User.sql
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto-incrementing primary key
        public int Id { get; set; }

        [Required] //Not nullable
        [MaxLength(50)] // Max length for username
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress] // Valid email format
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        //Store password as a hash
        [MaxLength(50)] 
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default to current time
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Default to current time

        //Navigation properties for Tea Stash or Brew Logs
        public ICollection<UserTeaStashEntry>? TeaStash { get; set; }
        // public ICollection<BrewSession>? BrewSession { get; set; }
    }
}
