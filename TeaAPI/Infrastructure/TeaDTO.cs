//Used for GET requests

namespace TeaAPI.Infrastructure
{
    public class TeaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; //e.g., Black, Green, Herbal
        public string? Subtype { get; set; } //e.g., Earl Grey, Jasmine, Sencha
        public string? CountryOrigin { get; set; } //e.g., China, India, Japan
        public string? Description { get; set; }
        public int? RecTemp { get; set; } //Nullable
        public int? RecTime { get; set; } //Nullable
    }
}
