using System.ComponentModel.DataAnnotations;

namespace TeaAPI.Infrastructure
{
    public class CreateUserTeaStashDTO
    {
        [Required(ErrorMessage = "TeaId is required.")]
        public int TeaId { get; set; }

        [Required(ErrorMessage = "QuantityOnHand is required.")]
        [MaxLength(50, ErrorMessage = "QuantityOnHand cannot exceed 50 characters.")]
        public string QuantityOnHand { get; set; } = string.Empty;

        public DateTime? PurchaseDate { get; set; } // Nullable to allow for optional purchase date

        [MaxLength(255, ErrorMessage = "Source cannot exceed 255 characters.")]
        public string Source { get; set; }

        [MaxLength(500, ErrorMessage = "StorageNotes cannot exceed 500 characters.")]
        public string StorageNotes { get; set; }

        [MaxLength(1000, ErrorMessage = "PersonalNotes cannot exceed 1000 characters.")]
        public string PersonalNotes { get; set; }
    }
}
