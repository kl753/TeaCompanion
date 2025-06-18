/*Main class that coordinates EFC functionality for 
 * data model.
 */
using Microsoft.EntityFrameworkCore;
using TeaAPI.Models; // Assuming the models are in the Models namespace

namespace TeaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet for Tea model
        public DbSet<Tea> Teas { get; set; } = null!; // Represents the Tea.sql table

        // Override OnModelCreating if you need to configure the model further
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Tea
            {
                Id = 1,
                Name = "Green Tea",
                Type = "Green",
                Subtype = "Matcha",
                CountryOfOrigin = "Japan",
                Description = "A finely ground powder of specially grown and processed green tea leaves.",
                RecTemp = 95, // Recommended brewing temperature in Celsius
                RecSteepTime = 180, // Recommended steeping time in seconds
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            new Tea
            {
                Id = 2,
                Name = "Black Tea",
                Type = "Black",
                Subtype = "Assam",
                CountryOfOrigin = "India",
                Description = "A strong, malty black tea from the Assam region.",
                RecTemp = 100, // Recommended brewing temperature in Celsius
                RecSteepTime = 240, // Recommended steeping time in seconds
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
