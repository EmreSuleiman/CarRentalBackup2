using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class ImagesSeededupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6064), "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745347666/Toyota-Camry_g1gdux.png", null, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6065) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6068), "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745347471/ibepkqn1ejafg2km95s7.png", null, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6068) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6074), "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745347665/Ford-Transit-Connect_jnyuvl.png", null, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6074) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6078), "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745347663/BMW-X5_viwmw2.png", null, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6079) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6083), "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745347662/VW-Transporter_c9imzq.png", null, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6088), "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745347663/Audi-A4_dr3l9v.png", null, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6092), "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745347891/Audi-A6_ji8clh.png", null, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6093) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Brand", "Category", "CreatedAt", "DailyRate", "Image", "LocationId", "Model", "PublicId", "Status", "UpdatedAt", "Year" },
                values: new object[] { 8, "Toyota", 0, new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6096), 90m, "https://res.cloudinary.com/dgpj1oq6q/image/upload/v1745348068/yaris_ssv9tt.png", 4, "Yaris", null, "В наличност", new DateTime(2025, 4, 22, 20, 33, 33, 405, DateTimeKind.Utc).AddTicks(6097), 2025 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9976), null, "Toyota-Camry_fbbsnr", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9979), null, "Toyota-Corolla_kqtmzl", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9979) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9983), null, "", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9983) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9986), null, "BMW-X5_cwv21v", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9987) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9990), null, "VW-Transporter_bzovd6", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9993), null, "Audi-A4_e1zasy", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Image", "PublicId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9996), null, "p1wiboqjwwxh8dxszkef", new DateTime(2025, 4, 22, 18, 30, 32, 666, DateTimeKind.Utc).AddTicks(9997) });
        }
    }
}
