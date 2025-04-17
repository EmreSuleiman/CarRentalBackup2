using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentDetailsToRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentDetails",
                table: "Rentals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDetails",
                table: "Rentals");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4581), new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4583), new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4585), new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4586) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4588), new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4590), new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4593), new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4595), new DateTime(2025, 4, 12, 17, 26, 13, 272, DateTimeKind.Utc).AddTicks(4595) });
        }
    }
}
