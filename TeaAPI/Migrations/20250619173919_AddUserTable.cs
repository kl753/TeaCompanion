using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "CountryOfOrigin", "CreatedAt", "Description", "Name", "RecSteepTime", "RecTemp", "Subtype", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Japan", new DateTime(2025, 6, 19, 17, 39, 18, 117, DateTimeKind.Utc).AddTicks(1244), "A finely ground powder of specially grown and processed green tea leaves.", "Green Tea", 180, 95, "Matcha", "Green", new DateTime(2025, 6, 19, 17, 39, 18, 117, DateTimeKind.Utc).AddTicks(1433) },
                    { 2, "India", new DateTime(2025, 6, 19, 17, 39, 18, 117, DateTimeKind.Utc).AddTicks(1622), "A strong, malty black tea from the Assam region.", "Black Tea", 240, 100, "Assam", "Black", new DateTime(2025, 6, 19, 17, 39, 18, 117, DateTimeKind.Utc).AddTicks(1623) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2025, 6, 19, 17, 39, 18, 313, DateTimeKind.Utc).AddTicks(5162), "test@example.com", "$2b$10$Hhmif.7fxXNF2iKIL2/joegNw01A6a8goB5HPpBF8yWVmO/EpDM4G", new DateTime(2025, 6, 19, 17, 39, 18, 313, DateTimeKind.Utc).AddTicks(5574), "test_tea_lover" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Teas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
