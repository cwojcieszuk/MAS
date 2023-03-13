using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class quickFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BetCoupons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "BetCoupons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
