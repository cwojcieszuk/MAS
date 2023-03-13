using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class simplifiedBetsAndCouponColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Coupons_CouponIdCoupon",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_CouponIdCoupon",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "CouponIdCoupon",
                table: "Bets");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_IdCoupon",
                table: "Bets",
                column: "IdCoupon");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets",
                column: "IdCoupon",
                principalTable: "Coupons",
                principalColumn: "IdCoupon",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_IdCoupon",
                table: "Bets");

            migrationBuilder.AddColumn<int>(
                name: "CouponIdCoupon",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bets_CouponIdCoupon",
                table: "Bets",
                column: "CouponIdCoupon");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Coupons_CouponIdCoupon",
                table: "Bets",
                column: "CouponIdCoupon",
                principalTable: "Coupons",
                principalColumn: "IdCoupon",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
