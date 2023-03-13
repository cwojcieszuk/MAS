using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class changedBetToCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerBets");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    IdCoupon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.IdCoupon);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCoupons",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false),
                    IdCoupon = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCoupons", x => new { x.IdPlayer, x.IdCoupon });
                    table.ForeignKey(
                        name: "FK_PlayerCoupons_Coupons_IdCoupon",
                        column: x => x.IdCoupon,
                        principalTable: "Coupons",
                        principalColumn: "IdCoupon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCoupons_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCoupons_IdCoupon",
                table: "PlayerCoupons",
                column: "IdCoupon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerCoupons");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    IdBet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.IdBet);
                });

            migrationBuilder.CreateTable(
                name: "PlayerBets",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false),
                    IdBet = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBets", x => new { x.IdPlayer, x.IdBet });
                    table.ForeignKey(
                        name: "FK_PlayerBets_Bets_IdBet",
                        column: x => x.IdBet,
                        principalTable: "Bets",
                        principalColumn: "IdBet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerBets_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBets_IdBet",
                table: "PlayerBets",
                column: "IdBet");
        }
    }
}
