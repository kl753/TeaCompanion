namespace TeaAPI.Infrastructure
{
    public class BrewLogDTO
    {
        public int Id { get; set; }
        public int UserTeaStashId { get; set; }
        public int TeaId { get; set; }
        public string TeaName { get; set; } = string.Empty; // Name of the tea for display purposes
        public DateTime BrewTime { get; set; } = DateTime.UtcNow;
        public int? Temp { get; set; } // Temperature in Celsius
        public int? SteepTime { get; set; } // Steep time in seconds
        public int? WaterAmount { get; set; } // Water amount in ml
        public int? UserRating { get; set; } // Rating from 1 to 5
        public string? BrewNotes { get; set; } // Notes about the brew
        public string? BrewMethod { get; set; } // Method used for brewing (e.g., Gaiwan, Teapot)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
