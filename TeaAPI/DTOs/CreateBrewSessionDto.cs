/*Transfer data class for creating a new tea
 * Used for POST requests to create a new tea entry.
 */
using System.ComponentModel.DataAnnotations;

namespace TeaAPI.DTOs
{
    public class CreateBrewSessionDto
    {
        [Required(ErrorMessage = "TeaId is required.")]
        public int TeaId { get; set; } // Foreign key to the tea used in the session

        public DateTime SessionDateTime { get; set; } = DateTime.UtcNow; // Default to current time

        [Range(0, 100, ErrorMessage = "Temperature must be between 0 and 100 degrees Celsius.")]
        public int? Temp { get; set; } // Temperature in Celsius, nullable if not specified

        [Range(0, 3600, ErrorMessage = "Steep time must be between 0 and 3600 seconds (1 hour).")]
        public int? SteepTime { get; set; } // Steep time in seconds, nullable if not specified

        [Required(ErrorMessage = "Rating is required.")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; } // User rating for the brew session (0-5)

        [MaxLength(1000)]
        public string? PersonalBrewNotes { get; set; } // Optional notes about the brew session

        [MaxLength(100)]
        public string? BrewMethod { get; set; } // Optional brew method (e.g., Gongfu, Western, Cold Brew)
    }
}
