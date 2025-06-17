using Microsoft.EntityFrameworkCore;
using TeaAPI.Models;

namespace TeaAPI.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tea> Teas { get; set; } = null!; // Represents the 'Teas' table in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // Configure the 'Teas' table
            modelBuilder.Entity<Tea>().HasData(
                new Tea
                {
                    Id = 1,
                    Name = "Earl Grey",
                    Type = "Black",
                    Subtype = "Flavored",
                    CountryOrigin = "UK",
                    Description = "A black tea flavored with oil of bergamot.",
                    RecTemp = 90,
                    RecTime = 240,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Tea
                {
                    Id = 2,
                    Name = "Sencha",
                    Type = "Green",
                    Subtype = null,
                    CountryOrigin = "Japan",
                    Description = "A popular Japanese green tea.",
                    RecTemp = 80,
                    RecTime = 180,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
