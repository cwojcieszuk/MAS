using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class addedBets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    IdBet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CouponIdCoupon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.IdBet);
                    table.ForeignKey(
                        name: "FK_Bets_Coupons_CouponIdCoupon",
                        column: x => x.CouponIdCoupon,
                        principalTable: "Coupons",
                        principalColumn: "IdCoupon");
                });

            migrationBuilder.CreateTable(
                name: "BetEvents",
                columns: table => new
                {
                    IdBetEvents = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBet = table.Column<int>(type: "int", nullable: false)
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
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBet = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Bets_CouponIdCoupon",
                table: "Bets",
                column: "CouponIdCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_BetSports_IdBet",
                table: "BetSports",
                column: "IdBet",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetEvents");

            migrationBuilder.DropTable(
                name: "BetSports");

            migrationBuilder.DropTable(
                name: "Bets");
        }
    }
}
