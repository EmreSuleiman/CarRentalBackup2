using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class ImagesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9976), "Toyota-Camry_fbbsnr", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9979), "Toyota-Corolla_kqtmzl", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9979) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9983), "", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9983) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9986), "BMW-X5_cwv21v", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9987) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9990), "VW-Transporter_bzovd6", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9993), "Audi-A4_e1zasy", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9996), "p1wiboqjwwxh8dxszkef", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9997) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
