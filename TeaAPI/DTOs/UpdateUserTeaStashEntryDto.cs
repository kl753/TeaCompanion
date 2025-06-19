/*Transfer data class for updating.
 * Used for PUT requests to update.
 */
using System.ComponentModel.DataAnnotations;

namespace TeaAPI.DTOs
{
    public class UpdateUserTeaStashEntryDto
    {
        [MaxLength(100)]
        public string? Quantity { get; set; } // e.g., "100g", "1 box"

        [MaxLength(250)]
        public string? Source { get; set; } // Optional source of the tea, e.g., "Local store", "Online shop"

        public DateTime? PurchaseDate { get; set; } // Optional purchase date, null if not provided
        //public DateTime? ExpiryDate { get; set; } // Optional expiry date, null if not provided

        [MaxLength(500)]
        public string? StorageNotes { get; set; } // Optional storage notes

        [MaxLength(1000)]
        public string? PersonalNotes { get; set; } // Optional personal notes
    }
}
