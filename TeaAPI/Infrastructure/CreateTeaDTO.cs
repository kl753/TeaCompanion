//Used for POST requests (creating a new tea)
using System.ComponentModel.DataAnnotations;

namespace TeaAPI.Infrastructure
{
    public class CreateTeaDTO
    {
        [Required(ErrorMessage = "Tea name is required.")]
        [MaxLength(50, ErrorMessage = "Tea name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tea type is required.")]
        [MaxLength(10, ErrorMessage = "Tea type cannot exceed 10 characters.")]
        public string Type { get; set; } = string.Empty; //e.g., Black, Green, Herbal

        [MaxLength(10, ErrorMessage = "Tea subtype cannot exceed 10 characters.")]
        public string? Subtype { get; set; } //e.g., Earl Grey, Jasmine, Sencha

        [MaxLength(10, ErrorMessage = "Country of origin cannot exceed 10 characters.")]
        public string? CountryOrigin { get; set; } //e.g., China, India, Japan

        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "Recommended temperature must be between 0 and 100 degrees celsius.")]
        public int? RecTemp { get; set; }

        [Range(0, 600, ErrorMessage = "Recommended time must be between 0 and 600 seconds.")]
        public int? RecTime { get; set; } 
    }
}
