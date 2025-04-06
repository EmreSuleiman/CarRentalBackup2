using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageToImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5338), new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5339) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5340), new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5343), new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5346), new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5347) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5349), new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5350) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5352), new DateTime(2025, 4, 6, 21, 17, 57, 656, DateTimeKind.Utc).AddTicks(5353) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
