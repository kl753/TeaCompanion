/*Main class that coordinates EFC functionality for 
 * data model.
 */
using Microsoft.EntityFrameworkCore;
//Will need to install BouncyCastle for hashing passwords
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators; 
using Org.BouncyCastle.Security;
using TeaAPI.Models; // Assuming the models are in the Models namespace

namespace TeaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet for Tea and User models
        public DbSet<Tea> Teas { get; set; } = null!; // Represents the Tea.sql table
        public DbSet<User> Users { get; set; } = null!; // Represents the User.sql table
        public DbSet<UserTeaStashEntry> UserTeaStashEntries { get; set; } = null!; // Represents the UserTeaStashEntry table

        // Override OnModelCreating if you need to configure the model further
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tea entity configuration
            modelBuilder.Entity<Tea>().HasData(
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
                },
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
                }
            );

            //User entity configuration
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("password123"); // Example password hash
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "test_tea_lover",
                    Email = "test@example.com",
                    PasswordHash = hashedPassword,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            //UserTeaStashEntry entity configuration
            modelBuilder.Entity<UserTeaStashEntry>()
                .HasOne(uts => uts.User)
                .WithMany(u => u.TeaStashEntries)
                .HasForeignKey(uts => uts.UserId);

            modelBuilder.Entity<UserTeaStashEntry>()
                .HasOne(uts => uts.Tea)
                .WithMany(t => t.UserTeaStashEntries)
                .HasForeignKey(uts => uts.TeaId);

            modelBuilder.Entity<UserTeaStashEntry>().HasData(
                new UserTeaStashEntry
                {
                    Id = 1,
                    UserId = 1, // Assuming the user with Id 1 exists
                    TeaId = 1, // Assuming the tea with Id 1 exists
                    Quantity = "100g", // Example quantity
                    Source = "Local store",
                    PurchaseDate = DateTime.UtcNow, // Purchased 30 days ago
                    StorageNotes = "Keep in a cool, dry place.",
                    PersonalNotes = "My favorite green tea!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // BrewSession entity configuration
            modelBuilder.Entity<BrewSession>()
                .HasOne(bs => bs.User)
                .WithMany(u => u.BrewSessions)
                .HasForeignKey(bs => bs.UserId);

            modelBuilder.Entity<BrewSession>()
                .HasOne(bs => bs.Tea)
                .WithMany(t => t.BrewSessions)
                .HasForeignKey(bs => bs.TeaId);

            modelBuilder.Entity<BrewSession>().HasData(
                new BrewSession
                {
                    Id = 1,
                    UserId = 1, // Assuming the user with Id 1 exists
                    TeaId = 1, // Assuming the tea with Id 1 exists
                    SessionDateTime = DateTime.UtcNow.AddDays(-30), // Brewed 30 days ago
                    Temp = 80, // Temperature in Celsius
                    SteepTime = 180, // Steep time in seconds
                    Rating = 5, // User rating for the brew session (0-5)
                    BrewMethod = "Gongfu", // Optional brew method (e.g., Gongfu, Western, Cold Brew)
                    PersonalBrewNotes = "Perfect brew!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

        }

        //// Helper method to hash passwords using BouncyCastle
        //private static string HashPassword(string password)
        //{
        //    var digest = new Sha256Digest();
        //    var generator = new Pkcs5S2ParametersGenerator(digest);
        //    var salt = new byte[16];
        //    new SecureRandom().NextBytes(salt);
        //    generator.Init(PbeParametersGenerator.Pkcs5PasswordToBytes(password.ToCharArray()), salt, 10000);
        //    var key = (KeyParameter)generator.GenerateDerivedMacParameters(256);
        //    return Convert.ToBase64String(key.GetKey());
        //}
    }
}