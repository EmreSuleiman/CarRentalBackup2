using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 13, 45, 123, DateTimeKind.Utc).AddTicks(9991), new DateTime(2025, 4, 4, 21, 13, 45, 123, DateTimeKind.Utc).AddTicks(9992) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 13, 45, 123, DateTimeKind.Utc).AddTicks(9992), new DateTime(2025, 4, 4, 21, 13, 45, 123, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(3), new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(5), new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(7), new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(8) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(9), new DateTime(2025, 4, 4, 21, 13, 45, 124, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "бул. Цариградско шосе 115", "София" },
                    { 2, "ул. Тракия 56", "Пловдив" },
                    { 3, "ул. Приморска 28", "Варна" },
                    { 4, "ул. Александровска 45", "Бургас" },
                    { 5, "ул. Борисова 12", "Русе" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7941), new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7943), new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7944) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7946), new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7946) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7948), new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7948) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7950), new DateTime(2025, 4, 4, 21, 10, 21, 308, DateTimeKind.Utc).AddTicks(7950) });
        }
    }
}
