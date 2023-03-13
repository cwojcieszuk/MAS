using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class lastDatabaseChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_IdCoupon",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "IdCoupon",
                table: "Bets");

            migrationBuilder.CreateTable(
                name: "BetCoupons",
                columns: table => new
                {
                    IdBet = table.Column<int>(type: "int", nullable: false),
                    IdCoupon = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetCoupons", x => new { x.IdBet, x.IdCoupon });
                    table.ForeignKey(
                        name: "FK_BetCoupons_Bets_IdBet",
                        column: x => x.IdBet,
                        principalTable: "Bets",
                        principalColumn: "IdBet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BetCoupons_Coupons_IdCoupon",
                        column: x => x.IdCoupon,
                        principalTable: "Coupons",
                        principalColumn: "IdCoupon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetCoupons_IdCoupon",
                table: "BetCoupons",
                column: "IdCoupon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetCoupons");

            migrationBuilder.AddColumn<int>(
                name: "IdCoupon",
                table: "Bets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bets_IdCoupon",
                table: "Bets",
                column: "IdCoupon");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Coupons_IdCoupon",
                table: "Bets",
                column: "IdCoupon",
                principalTable: "Coupons",
                principalColumn: "IdCoupon");
        }
    }
}
