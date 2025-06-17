using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaAPI.Models
{
    public class Tea
    {
        [Key] //Primary key attribute
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto-incrementing primary key
        public int Id { get; set; }

        [Required] //Not nullable
        [MaxLength(50)] //Maximum length of 50 characters
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Type { get; set; } = string.Empty; //e.g., Black, Green, Herbal

        [MaxLength(10)]
        public string? Subtype { get; set; } //e.g., Earl Grey, Jasmine, Sencha

        [MaxLength(10)]
        public string? CountryOrigin { get; set; } //e.g., China, India, Japan

        public string? Description { get; set; }

        public int? RecTemp { get; set; } //Nullable

        public int? RecTime { get; set; } //Nullable



        //Placeholder for created/updated timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
