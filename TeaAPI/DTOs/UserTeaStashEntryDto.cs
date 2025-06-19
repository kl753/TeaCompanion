/*Transfer data class for Tea
 * Used for GET requests to return data to the client.
 */

namespace TeaAPI.DTOs
{
    public class UserTeaStashEntryDto
    {
        public int Id { get; set; } // Auto-incrementing primary key
        public int UserId { get; set; } // Foreign key to User
        public int TeaId { get; set; } // Foreign key to Tea
        public string TeaName { get; set; } = string.Empty; // Name of the tea
        public string Quantity { get; set; } = string.Empty; // e.g., "100g", "1 box"
        public string? Source { get; set; } // Optional source of the tea, e.g., "Local store", "Online shop"
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow; // Default to current time
        //public DateTime? ExpiryDate { get; set; } // Optional expiry date, add to database schema if needed
        public string? StorageNotes { get; set; }
        public string? PersonalNotes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default to current time
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Default to current time
    }
}
