﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingLotManagament.Migrations
{
    public partial class AddedAmountToSubscriber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToBePaid",
                table: "Subscriptions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToBePaid",
                table: "Subscriptions");
        }
    }
}
