/*Transfer data class for Tea
 * Used for GET requests to return data to the client.
 */

namespace TeaAPI.DTOs
{
    public class BrewSessionDto
    {
        public int Id { get; set; } // Unique identifier for the brew session
        public int UserId { get; set; } // Foreign key to the user who created the session
        public int TeaId { get; set; } // Foreign key to the tea used in the session
        public string TeaName { get; set; } = string.Empty; // Name of the tea used in the session
        public DateTime SessionDateTime { get; set; } = DateTime.UtcNow; // Date and time of the brew session
        public int? Temp { get; set; } // Temperature in Celsius, nullable if not specified
        public int? SteepTime { get; set; } // Steep time in seconds, nullable if not specified
        public int? Rating { get; set; } // User rating for the brew session (0-5), nullable if not rated
        public string? PersonalBrewNotes { get; set; } // Optional notes about the brew session
        public string? BrewMethod { get; set; } // Optional brew method (e.g., Gongfu, Western, Cold Brew)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Creation timestamp
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Last updated timestamp
    }
}
