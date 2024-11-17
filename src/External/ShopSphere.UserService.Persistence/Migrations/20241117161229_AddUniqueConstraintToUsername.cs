using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopSphere.UserService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("2d7ad514-a50d-4d33-a5d6-d8e354feff06"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("47433a37-f80e-48fc-9f00-abde68799826"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "LastLogin", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("57e3bac9-ff2d-4ff3-a9e2-330a4bd0eece"), new DateTime(2024, 11, 17, 16, 12, 29, 189, DateTimeKind.Utc).AddTicks(4844), "admin@example.com", null, "$2a$11$Lwmq0x.VgRs6rf7ncBfNA.sFXWlADeSjcz4lotxuJqLgsk7dFzC0S", 0, "admin" },
                    { new Guid("f4c2c5f4-8be7-4c2f-a653-69bc46070f2b"), new DateTime(2024, 11, 17, 16, 12, 29, 325, DateTimeKind.Utc).AddTicks(4473), "user@example.com", null, "$2a$11$MZncmIetucdSzXrIAko2O.0MDw1qA880Co31.NocW6nFqGaE.Luni", 1, "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("57e3bac9-ff2d-4ff3-a9e2-330a4bd0eece"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f4c2c5f4-8be7-4c2f-a653-69bc46070f2b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "LastLogin", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("2d7ad514-a50d-4d33-a5d6-d8e354feff06"), new DateTime(2024, 11, 17, 16, 7, 51, 936, DateTimeKind.Utc).AddTicks(7660), "admin@example.com", null, "$2a$11$0fd3m8CJobJmdiQS5skdruucb8Ym71rvsIwNDXV9J1Sly6HZfhVI2", 0, "admin" },
                    { new Guid("47433a37-f80e-48fc-9f00-abde68799826"), new DateTime(2024, 11, 17, 16, 7, 52, 78, DateTimeKind.Utc).AddTicks(19), "user@example.com", null, "$2a$11$wEZVYLkFpdFXyBePNzHclOGvQSkRxvfcdGbO6BZVhV5Iiw9lnaHTi", 1, "user" }
                });
        }
    }
}
