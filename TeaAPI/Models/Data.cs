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
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserTeaStash> UserTeaStashes { get; set; } = null!;
        public DbSet<BrewLog> BrewLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure relationships
            modelBuilder.Entity<UserTeaStash>()
                .HasOne(uts => uts.User)
                .WithMany(u => u.TeaStash)
                .HasForeignKey(uts => uts.UserId);

            modelBuilder.Entity<UserTeaStash>()
                .HasOne(uts => uts.Tea)
                .WithMany() //No navigation property back to UserTeaStash directly
                .HasForeignKey(uts => uts.TeaId);

            modelBuilder.Entity<BrewLog>()
                .HasOne(bl => bl.UserTeaStash)
                .WithMany(uts => uts.BrewLogs)
                .HasForeignKey(bl => bl.UserTeaStashId)
                .OnDelete(DeleteBehavior.Cascade); //If stash item is deleted, delete its brew logs

            modelBuilder.Entity<BrewLog>()
                .HasOne(bl => bl.User)
                .WithMany()
                .HasForeignKey(bl => bl.UserId)
                .OnDelete(DeleteBehavior.Cascade); //If user is deleted, delete their brew logs

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

            //Example User Seed Data
            var userId1 = 1;
            var teaId3 = 3;
            var teaId4 = 4;

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId1,
                    Username = "tea_lover_1",
                    Email = "tea_lover_1@example.com",
                    PasswordHash = "hashed_password_1", //BCrypt.Net.BCrypt.HashPassword("hashed_password_1"),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                } 
            );

            var UserTeaStashId1 = 1;
            var UserTeaStashId2 = 2;

            modelBuilder.Entity<UserTeaStash>().HasData(
                new UserTeaStash
                {
                    Id = UserTeaStashId1,
                    UserId = userId1,
                    TeaId = teaId3, //Assuming teaId3 exists in the Teas table
                    QuantityOnHand = "50g",
                    PurchaseDate = DateTime.UtcNow.AddDays(-30),
                    Source = "Local Tea Shop",
                    StorageNotes = "Keep in a cool, dry place",
                    PersonalNotes = "Great for mornings",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new UserTeaStash
                {
                    Id = UserTeaStashId2,
                    UserId = userId1,
                    TeaId = teaId4, //Assuming teaId4 exists in the Teas table
                    QuantityOnHand = "100g",
                    PurchaseDate = DateTime.UtcNow.AddDays(-15),
                    Source = "Online Store",
                    StorageNotes = "Store in an airtight container",
                    PersonalNotes = "Best with honey",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<BrewLog>().HasData(
                new BrewLog
                {
                    Id = 1,
                    UserTeaStashId = UserTeaStashId1,
                    UserId = userId1,
                    BrewedTime  = DateTime.UtcNow.AddDays(-1),
                    Temp = 90,
                    SteepTime = 240,
                    WaterAmount = 300,
                    Rating = 4,
                    BrewNotes = "Perfect balance of flavor and aroma.",
                    BrewMethod = "Teapot",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new BrewLog
                {
                    Id = 2,
                    UserTeaStashId = UserTeaStashId2,
                    UserId = userId1,
                    BrewedTime = DateTime.UtcNow.AddDays(-3),
                    Temp = 80,
                    SteepTime = 180,
                    WaterAmount = 250,
                    Rating = 4,
                    BrewNotes = "Too weak, needs more leaves.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
