using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class simplifiedBets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Coupons_CouponIdCoupon",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "BetEvents");

            migrationBuilder.DropTable(
                name: "BetSports");

            migrationBuilder.AlterColumn<int>(
                name: "CouponIdCoupon",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BetType",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCoupon",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SportName",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Coupons_CouponIdCoupon",
                table: "Bets",
                column: "CouponIdCoupon",
                principalTable: "Coupons",
                principalColumn: "IdCoupon",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Coupons_CouponIdCoupon",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BetType",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "IdCoupon",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "SportName",
                table: "Bets");

            migrationBuilder.AlterColumn<int>(
                name: "CouponIdCoupon",
                table: "Bets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "BetEvents",
                columns: table => new
                {
                    IdBetEvents = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBet = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetEvents", x => x.IdBetEvents);
                    table.ForeignKey(
                        name: "FK_BetEvents_Bets_IdBet",
                        column: x => x.IdBet,
                        principalTable: "Bets",
                        principalColumn: "IdBet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BetSports",
                columns: table => new
                {
                    IdBetSports = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBet = table.Column<int>(type: "int", nullable: false),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetSports", x => x.IdBetSports);
                    table.ForeignKey(
                        name: "FK_BetSports_Bets_IdBet",
                        column: x => x.IdBet,
                        principalTable: "Bets",
                        principalColumn: "IdBet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetEvents_IdBet",
                table: "BetEvents",
                column: "IdBet",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BetSports_IdBet",
                table: "BetSports",
                column: "IdBet",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Coupons_CouponIdCoupon",
                table: "Bets",
                column: "CouponIdCoupon",
                principalTable: "Coupons",
                principalColumn: "IdCoupon");
        }
    }
}
