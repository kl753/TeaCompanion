/*Transfer data class for updating an existing tea
 * Used for PUT requests to update an existing tea entry.
 */
using System.ComponentModel.DataAnnotations;

namespace TeaAPI.DTOs
{
    public class UpdateTeaDto
    {
        //No Id, as it is passed in the URL for PUT requests

        [Required(ErrorMessage = "Tea name is required.")]
        [MaxLength(100, ErrorMessage = "Tea name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty; // Name of the tea

        [Required(ErrorMessage = "Tea type is required.")]
        [MaxLength(50, ErrorMessage = "Tea type cannot exceed 50 characters.")]
        public string Type { get; set; } = string.Empty; // Type of tea (e.g., Black, Green, Herbal)

        [MaxLength(50, ErrorMessage = "Tea subtype cannot exceed 50 characters.")]
        public string? Subtype { get; set; } // Subtype of tea (e.g., Oolong, Matcha)

        [MaxLength(100, ErrorMessage = "Country of origin cannot exceed 100 characters.")]
        public string? CountryOfOrigin { get; set; } // Country where the tea originates

        public string? Description { get; set; } // Description of the tea

        [Range(0, 100, ErrorMessage = "Recommended temperature must be between 0 and 100 degrees Celsius.")]
        public int ? RecTemp { get; set; } // Recommended brewing temperature in Celsius

        [Range(0, 3600, ErrorMessage = "Recommended steep time must be between 0 and 3600 seconds.")]
        public int? RecSteepTime { get; set; } // Recommended steeping time in seconds
    }
}
