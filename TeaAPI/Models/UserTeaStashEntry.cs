/*Represents a specific tea owned by a user.
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaAPI.Models
{
    public class UserTeaStashEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Auto-incrementing primary key

        //Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; } = null!; // Navigation property to User

        //Foreign key to Tea
        public int TeaId { get; set; }
        public Tea Tea { get; set; } = null!; // Navigation property to Tea

        [Required]
        [MaxLength(100)]
        public string Quantity { get; set; } = string.Empty; // e.g., "100g", "1 box"

        [MaxLength(250)]
        public string? Source { get; set; } // Optional source of the tea, e.g., "Local store", "Online shop"

        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow; // Default to current time
        //public DateTime? ExpiryDate { get; set; } // Optional expiry date, add to database schema if needed

        [MaxLength(500)]
        public string? StorageNotes { get; set; }

        [MaxLength(1000)]
        public string? PersonalNotes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default to current time
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Default to current time
    }
}
