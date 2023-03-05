using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingLotManagament.Migrations
{
    public partial class FixIsDeletedDefaultFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "ParkingLots");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "ParkingLots",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
