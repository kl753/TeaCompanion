/*Transfer data class for Tea
 * Used for GET requests to return data to the client.
 */

namespace TeaAPI.DTOs
{
    public class TeaDto
    {
        public int Id { get; set; } // Unique identifier for the tea
        public string Name { get; set; } = string.Empty; // Name of the tea
        public string Type { get; set; } = string.Empty; // Type of tea (e.g., Black, Green, Herbal)
        public string? Subtype { get; set; } // Subtype of tea (e.g., Oolong, Matcha)
        public string? CountryOfOrigin { get; set; } // Country where the tea originates
        public string? Description { get; set; } // Description of the tea
        public int? RecTemp { get; set; } // Recommended brewing temperature in Celsius
        public int? RecSteepTime { get; set; } // Recommended steeping time in seconds
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp when the tea was created
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Timestamp when the tea was last updated
    }
}
