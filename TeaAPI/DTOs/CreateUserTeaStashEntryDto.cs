/*Transfer data class for creating a new tea
 * Used for POST requests to create a new tea entry.
 */
using System.ComponentModel.DataAnnotations;

namespace TeaAPI.DTOs
{
    public class CreateUserTeaStashEntryDto
    {
        [Required(ErrorMessage = "Tea Id is required.")]
        public int TeaId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [MaxLength(100)]
        public string Quantity { get; set; } = string.Empty; // e.g., "100g", "1 box"

        [MaxLength(250)]
        public string? Source { get; set; } // Optional source of the tea, e.g., "Local store", "Online shop"

        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow; // Default to current time
        //public DateTime? ExpiryDate { get; set; } // Optional expiry date, add to database schema if needed

        [MaxLength(500)]
        public string? StorageNotes { get; set; } // Optional storage notes

        [MaxLength(1000)]
        public string? PersonalNotes { get; set; } // Optional personal notes
    }
}
