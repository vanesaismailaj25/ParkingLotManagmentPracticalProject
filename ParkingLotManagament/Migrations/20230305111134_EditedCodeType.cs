using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingLotManagament.Migrations
{
    public partial class EditedCodeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Code",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
