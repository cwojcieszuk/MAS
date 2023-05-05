using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserAccountRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetEsport",
                columns: table => new
                {
                    IdBetEsport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Team1 = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Team2 = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetEsport_pk", x => x.IdBetEsport);
                });

            migrationBuilder.CreateTable(
                name: "BetEsportType",
                columns: table => new
                {
                    IdBetEsportType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetEsportType_pk", x => x.IdBetEsportType);
                });

            migrationBuilder.CreateTable(
                name: "BetSport",
                columns: table => new
                {
                    IdBetSport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Team1 = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Team2 = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetSport_pk", x => x.IdBetSport);
                });

            migrationBuilder.CreateTable(
                name: "BetSportType",
                columns: table => new
                {
                    IdBetSportType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetSportType_pk", x => x.IdBetSportType);
                });

            migrationBuilder.CreateTable(
                name: "BetStatus",
                columns: table => new
                {
                    IdBetStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetStatus_pk", x => x.IdBetStatus);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    IdCoupon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalRate = table.Column<double>(type: "float", nullable: false),
                    PotentialWin = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Coupon_pk", x => x.IdCoupon);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    IdOffer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Bonus = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Offer_pk", x => x.IdOffer);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    Pesel = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    RefreshTokenExpiration = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    IdBet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdBetSport = table.Column<int>(type: "int", nullable: true),
                    IdBetEsport = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Bet_pk", x => x.IdBet);
                    table.ForeignKey(
                        name: "Bet_BetEsport",
                        column: x => x.IdBetEsport,
                        principalTable: "BetEsport",
                        principalColumn: "IdBetEsport");
                    table.ForeignKey(
                        name: "Bet_BetSport",
                        column: x => x.IdBetSport,
                        principalTable: "BetSport",
                        principalColumn: "IdBetSport");
                });

            migrationBuilder.CreateTable(
                name: "BetEsportOption",
                columns: table => new
                {
                    IdBetEsportOption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBetEsportType = table.Column<int>(type: "int", nullable: false),
                    IdBetEsport = table.Column<int>(type: "int", nullable: false),
                    Odds = table.Column<float>(type: "real", nullable: false),
                    IdBetStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetEsportOption_pk", x => x.IdBetEsportOption);
                    table.ForeignKey(
                        name: "BetEsportOption_BetEsport",
                        column: x => x.IdBetEsport,
                        principalTable: "BetEsport",
                        principalColumn: "IdBetEsport");
                    table.ForeignKey(
                        name: "BetEsportOption_BetEsportType",
                        column: x => x.IdBetEsportType,
                        principalTable: "BetEsportType",
                        principalColumn: "IdBetEsportType");
                    table.ForeignKey(
                        name: "BetEsportOption_BetStatus",
                        column: x => x.IdBetStatus,
                        principalTable: "BetStatus",
                        principalColumn: "IdBetStatus");
                });

            migrationBuilder.CreateTable(
                name: "BetSportOption",
                columns: table => new
                {
                    IdBetSportOption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBetSportType = table.Column<int>(type: "int", nullable: false),
                    IdBetSport = table.Column<int>(type: "int", nullable: false),
                    Odds = table.Column<float>(type: "real", nullable: false),
                    IdBetStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetSportOption_pk", x => x.IdBetSportOption);
                    table.ForeignKey(
                        name: "BetSportTypeOdds_BetSport",
                        column: x => x.IdBetSport,
                        principalTable: "BetSport",
                        principalColumn: "IdBetSport");
                    table.ForeignKey(
                        name: "BetSportTypeOdds_BetSportType",
                        column: x => x.IdBetSportType,
                        principalTable: "BetSportType",
                        principalColumn: "IdBetSportType");
                    table.ForeignKey(
                        name: "BetSportTypeOdds_BetStatus",
                        column: x => x.IdBetStatus,
                        principalTable: "BetStatus",
                        principalColumn: "IdBetStatus");
                });

            migrationBuilder.CreateTable(
                name: "CouponOffer",
                columns: table => new
                {
                    IdCouponOffer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCoupon = table.Column<int>(type: "int", nullable: false),
                    IdOffer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CouponOffer_pk", x => new { x.IdCouponOffer, x.IdCoupon, x.IdOffer });
                    table.ForeignKey(
                        name: "CouponOffer_Coupon",
                        column: x => x.IdCoupon,
                        principalTable: "Coupon",
                        principalColumn: "IdCoupon");
                    table.ForeignKey(
                        name: "CouponOffer_Offer",
                        column: x => x.IdOffer,
                        principalTable: "Offer",
                        principalColumn: "IdOffer");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false),
                    BankAccount = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Account_pk", x => x.IdAccount);
                    table.ForeignKey(
                        name: "Account_User",
                        column: x => x.IdAccount,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    City = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    State = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Address_pk", x => x.IdAddress);
                    table.ForeignKey(
                        name: "Address_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Admin_pk", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "Admin_User",
                        column: x => x.IdAdmin,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Player_pk", x => x.IdPlayer);
                    table.ForeignKey(
                        name: "Player_User",
                        column: x => x.IdPlayer,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "PlayerBet",
                columns: table => new
                {
                    IdPlayerBet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdCoupon = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PlayerBet_pk", x => new { x.IdPlayerBet, x.IdUser, x.IdCoupon });
                    table.ForeignKey(
                        name: "PlayerBet_Coupon",
                        column: x => x.IdCoupon,
                        principalTable: "Coupon",
                        principalColumn: "IdCoupon");
                    table.ForeignKey(
                        name: "PlayerBet_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "BetCoupon",
                columns: table => new
                {
                    IdBetCoupon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCoupon = table.Column<int>(type: "int", nullable: false),
                    IdBetSportOption = table.Column<int>(type: "int", nullable: true),
                    IdBetEsportOption = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetCoupon_pk", x => new { x.IdBetCoupon, x.IdCoupon });
                    table.ForeignKey(
                        name: "BetCoupon_BetEsportOption",
                        column: x => x.IdBetEsportOption,
                        principalTable: "BetEsportOption",
                        principalColumn: "IdBetEsportOption");
                    table.ForeignKey(
                        name: "BetCoupon_BetSportOption",
                        column: x => x.IdBetSportOption,
                        principalTable: "BetSportOption",
                        principalColumn: "IdBetSportOption");
                    table.ForeignKey(
                        name: "BetCoupon_Coupon",
                        column: x => x.IdCoupon,
                        principalTable: "Coupon",
                        principalColumn: "IdCoupon");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_IdUser",
                table: "Address",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_IdBetEsport",
                table: "Bet",
                column: "IdBetEsport");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_IdBetSport",
                table: "Bet",
                column: "IdBetSport");

            migrationBuilder.CreateIndex(
                name: "IX_BetCoupon_IdBetEsportOption",
                table: "BetCoupon",
                column: "IdBetEsportOption");

            migrationBuilder.CreateIndex(
                name: "IX_BetCoupon_IdBetSportOption",
                table: "BetCoupon",
                column: "IdBetSportOption");

            migrationBuilder.CreateIndex(
                name: "IX_BetCoupon_IdCoupon",
                table: "BetCoupon",
                column: "IdCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_BetEsportOption_IdBetEsport",
                table: "BetEsportOption",
                column: "IdBetEsport");

            migrationBuilder.CreateIndex(
                name: "IX_BetEsportOption_IdBetEsportType",
                table: "BetEsportOption",
                column: "IdBetEsportType");

            migrationBuilder.CreateIndex(
                name: "IX_BetEsportOption_IdBetStatus",
                table: "BetEsportOption",
                column: "IdBetStatus");

            migrationBuilder.CreateIndex(
                name: "IX_BetSportOption_IdBetSport",
                table: "BetSportOption",
                column: "IdBetSport");

            migrationBuilder.CreateIndex(
                name: "IX_BetSportOption_IdBetSportType",
                table: "BetSportOption",
                column: "IdBetSportType");

            migrationBuilder.CreateIndex(
                name: "IX_BetSportOption_IdBetStatus",
                table: "BetSportOption",
                column: "IdBetStatus");

            migrationBuilder.CreateIndex(
                name: "IX_CouponOffer_IdCoupon",
                table: "CouponOffer",
                column: "IdCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_CouponOffer_IdOffer",
                table: "CouponOffer",
                column: "IdOffer");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBet_IdCoupon",
                table: "PlayerBet",
                column: "IdCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBet_IdUser",
                table: "PlayerBet",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "BetCoupon");

            migrationBuilder.DropTable(
                name: "CouponOffer");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "PlayerBet");

            migrationBuilder.DropTable(
                name: "BetEsportOption");

            migrationBuilder.DropTable(
                name: "BetSportOption");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BetEsport");

            migrationBuilder.DropTable(
                name: "BetEsportType");

            migrationBuilder.DropTable(
                name: "BetSport");

            migrationBuilder.DropTable(
                name: "BetSportType");

            migrationBuilder.DropTable(
                name: "BetStatus");
        }
    }
}
