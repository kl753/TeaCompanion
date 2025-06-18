using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaAPI.Models
{
    public class BrewLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Foreign key to UserTeaStash
        [Required]
        public int UserTeaStashId { get; set; }
        public UserTeaStash UserTeaStash { get; set; } = null!; //Navigation property

        //Foreign key to User
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!; //Navigation property

        public DateTime BrewedTime { get; set; } = DateTime.UtcNow;

        [Range(0, 100, ErrorMessage = "Temp must be between 0 and 100 Celsius.")]
        public int? Temp { get; set; }

        [Range(0, 600, ErrorMessage = "Steep time must be between 0 and 600 seconds.")]
        public int? SteepTime { get; set; }

        [Range(0, 1000, ErrorMessage = "Water amount must be between 0 and 1000 ml.")]
        public int? WaterAmount { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? UserRating { get; set; }

        [MaxLength(1000)]
        public string? BrewNotes { get; set; } //e.g., "Used a gaiwan", "Added honey", "Felt too bitter"

        [MaxLength(50)]
        public string? BrewMethod { get; set; } //e.g., "Gaiwan", "Teapot", "French Press"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
