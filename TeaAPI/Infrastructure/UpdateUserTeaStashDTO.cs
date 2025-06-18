using System.ComponentModel.DataAnnotations;

namespace TeaAPI.Infrastructure
{
    public class UpdateUserTeaStashDTO
    {
        [Required(ErrorMessage = "Quantity on hand is required.")]
        [MaxLength(50, ErrorMessage = "Quantity on hand cannot exceed 50 characters.")]
        public string QuantityOnHand { get; set; } = string.Empty;

        public DateTime? PurchaseDate { get; set; } // Nullable to allow for optional purchase date

        [MaxLength(255, ErrorMessage = "Source cannot exceed 255 characters.")]
        public string? Source { get; set; } // Nullable to allow for optional source

        [MaxLength(500, ErrorMessage = "Storage notes cannot exceed 500 characters.")]
        public string? StorageNotes { get; set; } // Nullable to allow for optional storage notes

        [MaxLength(1000, ErrorMessage = "Personal notes cannot exceed 1000 characters.")]
        public string? PersonalNotes { get; set; } // Nullable to allow for optional personal notes
    }
}
