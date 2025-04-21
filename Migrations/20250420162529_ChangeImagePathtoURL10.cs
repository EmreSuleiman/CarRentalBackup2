using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImagePathtoURL10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2203), null, new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2206), null, new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2212), null, new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2216), null, new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2220), null, new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2224), null, new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2225) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2228), null, new DateTime(2025, 4, 20, 16, 25, 27, 724, DateTimeKind.Utc).AddTicks(2229) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7732), "https://global.toyota/pages/models/images/camry/camry_010_s.jpg", new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7733) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7735), "https://di-uploads-pod3.dealerinspire.com/riversidetoyota/uploads/2018/12/2019-Toyota-Corolla-L-123118-copy.png", new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7741), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQle7rOjsAdhTfpggSwLzKnflAShadVzCWb7Q&s", new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7742) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7746), "https://prod.cosy.bmw.cloud/bmwweb/cosySec?COSY-EU-100-7331rjFhnOqIbqcTZ%25L3hpvYLfCny2oWYgpnQ97lX80UrOohZkVAfS5cVLNHCLvhJP%25z6eEzFu4fXBjvWzmQltE6BmudhSId4k9VTCrmpIUrOrJrhDGwXHi4T4qF9%25rJHFlFe6ou4TJIsIUzL3FlTv0VliyXIslGAzWECrv0s9OaRBE4GA0ogRwlNF9OALUxnXkIogOybW5KnvLUgChe2B5GybUEqjpx89ChbNmQtiPoEqhk7ZnHMLNmqn1cmaDyk7m5VKGPYCn178zB3vtE5V1Pa28mfN8zVMRpoMSkPazDxTKAdnMRaYWlALQ5DxRtesOwZ8YWxfj0gKcPteWS6AdaKMfjedwOQNBDS6jQ%25gZp2Ydw6ZuUNfptQ%25wc3bnFifZu%25KXh5JHSc3uBrq9YJdKX324mIKTQBrXpF7CAlZ24riI15ascpF4HvVAA0KiIFJGz7xABHvIT9a1nO2JGvloILUgpT9GsLvS6Uilo90yG10bHsLoAC9VshJ0yLOEozxqTACygNLpfmlOECUkaKH7sgNEbnR2V10UkNh5xWqVAbnkq8WeszOh5nmPej4agq857MjK0RUmP81D6psxb7MPVYws5Wh1DMzt%25r0eqVYDafu46jmztYRSaLP67aftxdRyww1RSfWQxDD%25VxdSeZWCuuzWQdjceTE3aeZQ6KjPpXRjcZwBZvHrx6Kc%252cqJ4WwBKupK5jFe%252B3iBucIjup2XH2fwv63iprJp9eGwXHi4TfF99%25UHNMClix2t5JUABNItPb9FSrTLn9lVc%25s6l89RpC0vQFju1dWS2aOIXRTVcwL9cvtT7672yzH3OYgMTN6uQmlDTI0Ccy2of4Y", new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7747) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7750), "https://autochill.ru/wp-content/uploads/2021/03/kisspng-van-volkswagen-polo-car-volkswagen-transporter-5b0392784fe112.8189206915269607603272-removebg-preview.png", new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7751) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7754), "https://platform.cstatic-images.com/in/v2/stock_photos/c4359896-c20e-46da-87a2-a7b2734561b3/c0535e58-31b9-488d-b5b7-55818402e3e6.png", new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Image", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7759), "https://d2ivfcfbdvj3sm.cloudfront.net/7fc965ab77efe6e0fa62e4ca1ea7673bb25e46590c1e3d8e88cb10/stills_0640_png/MY2021/14787/14787_st0640_116.png", new DateTime(2025, 4, 20, 12, 35, 0, 781, DateTimeKind.Utc).AddTicks(7759) });
        }
    }
}
