using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class addedMissingFieldsToCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FullRate",
                table: "Coupons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PotentialWin",
                table: "Coupons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullRate",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "PotentialWin",
                table: "Coupons");
        }
    }
}
