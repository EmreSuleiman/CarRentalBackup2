using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImagePathtoURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Cars",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7732), new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7733) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7735), new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7741), new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7742) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7746), new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7747) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7751) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7754), new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7759), new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7759) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Cars",
                newName: "ImagePath");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5697), new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5698) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5699), new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5699) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5702), new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5702) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5766), new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5768), new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5771), new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5772) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5774), new DateTime(2025, 4, 13, 21, 9, 9, 461, DateTimeKind.Utc).AddTicks(5774) });
        }
    }
}
