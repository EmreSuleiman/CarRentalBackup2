using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class publicidnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Cars",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2552), null, new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2555), null, new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2560), null, new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2561) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2564), null, new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2565) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2568), null, new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2569) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2572), null, new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2576), null, new DateTime(2025, 4, 20, 19, 15, 58, 788, DateTimeKind.Utc).AddTicks(2576) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2203), new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2206), new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2212), new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2216), new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2220), new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2224), new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2225) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2228), new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2229) });
        }
    }
}
