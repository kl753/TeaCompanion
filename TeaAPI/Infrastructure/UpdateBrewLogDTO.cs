using System.ComponentModel.DataAnnotations;

namespace TeaAPI.Infrastructure
{
    public class UpdateBrewLogDTO
    {
        public DateTime? BrewTime { get; set; } // Nullable to allow for optional brew time

        [Range(0, 100, ErrorMessage = "Temperature must be between 0 and 100 Celsius.")]
        public int? Temp { get; set; } // Temperature in Celsius

        [Range(0, 600, ErrorMessage = "Steep time must be between 0 and 600 seconds.")]
        public int? SteepTime { get; set; } // Steep time in seconds

        [Range(0, 1000, ErrorMessage = "Water amount must be between 0 and 1000 ml.")]
        public int? WaterAmount { get; set; } // Water amount in ml

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? Rating { get; set; } // Rating from 1 to 5

        [MaxLength(1000, ErrorMessage = "Brew notes cannot exceed 1000 characters.")]
        public string? BrewNotes { get; set; } // Notes about the brew

        [MaxLength(50, ErrorMessage = "Brew method cannot exceed 50 characters.")]
        public string? BrewDescription { get; set; }
    }
}
