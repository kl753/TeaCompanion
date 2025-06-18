namespace TeaAPI.Infrastructure
{
    public class UserTeaStashDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TeaId { get; set; }
        public string TeaName { get; set; } = string.Empty; // Name of the tea for display purposes
        public string QuantityOnHand { get; set; } = string.Empty;
        public DateTime? PurchaseDate { get; set; }
        public string? Source { get; set; }
        public string? StorageNotes { get; set; }
        public string? PersonalNotes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
