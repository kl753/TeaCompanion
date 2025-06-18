/*Represents Tea table in the database.
 * Tea.sql
 * Possibly update to match Tea.sql database schema.
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaAPI.Models
{
    public class Tea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrementing primary key
        public int Id { get; set; }

        [Required] //Not nullable
        [MaxLength(100)] // Maximum length of 100 characters
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty; //e.g., Black, Green, Herbal

        [MaxLength(50)]
        public string? Subtype { get; set; } //e.g., Oolong, Matcha, etc.

        [MaxLength(100)]
        public string? CountryOfOrigin { get; set; } //e.g., China, India, Japan

        public string? Description { get; set; } // Optional description of the tea

        public int? RecTemp { get; set; } // Recommended brewing temperature in Celsius

        public int? RecSteepTime { get; set; } // Recommended steeping time in seconds

        //Could add navigation properties with FlavorTag
        //public ICollection<FlavorTag> FlavorTags { get; set; }

        //Placeholder for created/updated timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
