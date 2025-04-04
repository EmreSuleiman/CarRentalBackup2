using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class BlacklistUserUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlacklistReason",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 14, 53, 25, 759, DateTimeKind.Utc).AddTicks(3150), new DateTime(2025, 4, 4, 14, 53, 25, 759, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 14, 53, 25, 759, DateTimeKind.Utc).AddTicks(3151), new DateTime(2025, 4, 4, 14, 53, 25, 759, DateTimeKind.Utc).AddTicks(3152) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlacklistReason",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 24, 19, 5, 57, 999, DateTimeKind.Utc).AddTicks(2601), new DateTime(2025, 3, 24, 19, 5, 57, 999, DateTimeKind.Utc).AddTicks(2602) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 24, 19, 5, 57, 999, DateTimeKind.Utc).AddTicks(2603), new DateTime(2025, 3, 24, 19, 5, 57, 999, DateTimeKind.Utc).AddTicks(2603) });
        }
    }
}
