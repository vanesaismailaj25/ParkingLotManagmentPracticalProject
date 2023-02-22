using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingLotManagament.Migrations
{
    public partial class AddedDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parking Lot",
                columns: new[] { "Id", "IsReserved", "ParkingName", "SubscriptionId" },
                values: new object[,]
                {
                    { 1, false, "A1", null },
                    { 2, false, "A2", null },
                    { 3, false, "A3", null },
                    { 4, false, "A4", null },
                    { 5, false, "B1", null },
                    { 6, false, "B2", null },
                    { 7, false, "B3", null },
                    { 8, false, "B4", null },
                    { 9, false, "C1", null },
                    { 10, false, "C2", null },
                    { 11, false, "C3", null },
                    { 12, false, "C4", null }
                });

            migrationBuilder.InsertData(
                table: "Pricing Plans",
                columns: new[] { "Id", "DailyPricing", "HourlyPricing", "MinimumHours", "Weekend" },
                values: new object[,]
                {
                    { 1, 800m, 100m, new DateTime(2023, 2, 19, 15, 34, 41, 617, DateTimeKind.Local).AddTicks(5445), false },
                    { 2, 500m, 80m, new DateTime(2023, 2, 19, 15, 34, 41, 617, DateTimeKind.Local).AddTicks(5494), true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parking Lot",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pricing Plans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pricing Plans",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
