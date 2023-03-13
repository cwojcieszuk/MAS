using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class allowedIdCouponToBeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets");

            migrationBuilder.AlterColumn<int>(
                name: "IdCoupon",
                table: "Bets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets",
                column: "IdCoupon",
                principalTable: "Coupons",
                principalColumn: "IdCoupon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets");

            migrationBuilder.AlterColumn<int>(
                name: "IdCoupon",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets",
                column: "IdCoupon",
                principalTable: "Coupons",
                principalColumn: "IdCoupon",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
