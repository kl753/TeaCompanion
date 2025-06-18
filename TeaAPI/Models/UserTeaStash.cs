using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaAPI.Models
{
    public class UserTeaStash
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Foreign key to User
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!; //Navigation property

        //Foreign key to Tea
        [Required]
        public int TeaId { get; set; }
        public Tea Tea { get; set; } = null!; //Navigation property

        [Required]
        [MaxLength(50)]
        public string QuantityOnHand { get; set; } = string.Empty; //e.g., "50g", "100g", "1 box"

        public DateTime? PurchaseDate { get; set; };

        [MaxLength(255)]
        public string? Source { get; set; } //e.g., "Local Tea Shop", "Online Store"

        [MaxLength(500)]
        public string? StorageNotes { get; set; } //e.g., "Keep in a cool, dry place", "Store in an airtight container"

        [MaxLength(1000)]
        public string? PersonalNotes { get; set; } //e.g., "Great for mornings", "Best with honey"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //Navigation property for brewing sessions related to this specific stash item
        public ICollection<BrewingLog>? BrewingLogs { get; set; }
    }
}
