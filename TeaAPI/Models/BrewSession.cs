using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaAPI.Models
{
    public class BrewSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        //Foreign key to Tea
        public int TeaId { get; set; }
        public Tea Tea { get; set; }

        public DateTime SessionDateTime { get; set; } = DateTime.UtcNow; // Default to current time

        [Range(0, 100)]
        public int? Temp { get; set; } // Temperature in Celsius

        [Range(0, 3600)] // Max 1 hour steep time
        public int? SteepTime { get; set; } // Steep time in seconds

        [Range(0, 5)]
        public int? Rating { get; set; } // User rating for the brew session (0-5)

        [MaxLength(1000)]
        public string? PersonalBrewNotes { get; set; } // Optional notes about the brew session

        [MaxLength(100)]
        public string? BrewMethod { get; set; } // Optional brew method (e.g., Gongfu, Western, Cold Brew)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default to current time
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Default to current time
    }
}
