using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAS.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BetEsport",
                columns: new[] { "IdBetEsport", "GameName", "Team1", "Team2" },
                values: new object[,]
                {
                    { 1, "CS:GO", "FaZe Clan", "Virtus Pro" },
                    { 2, "CS:GO", "NIP", "Vitality" },
                    { 3, "CS:GO", "Cloud9", "G2" }
                });

            migrationBuilder.InsertData(
                table: "BetEsportType",
                columns: new[] { "IdBetEsportType", "Name" },
                values: new object[,]
                {
                    { 1, "Wygra 1 drużyna" },
                    { 2, "Wygra 2 drużyna" },
                    { 3, "Remis" }
                });

            migrationBuilder.InsertData(
                table: "BetSport",
                columns: new[] { "IdBetSport", "SportName", "Team1", "Team2" },
                values: new object[,]
                {
                    { 1, "Piłka nożna", "Manchester United", "Manchester City" },
                    { 2, "Piłka nożna", "Arsenal", "Liverpool" },
                    { 3, "Piłka nożna", "Fc Barcelona", "Real Madryt" },
                    { 4, "Piłka nożna", "PSG", "Bayern Monachium" }
                });

            migrationBuilder.InsertData(
                table: "BetSportType",
                columns: new[] { "IdBetSportType", "Name" },
                values: new object[,]
                {
                    { 1, "Wygra 1 drużyna" },
                    { 2, "Wygra 1 drużyna" },
                    { 3, "Remis" }
                });

            migrationBuilder.InsertData(
                table: "BetStatus",
                columns: new[] { "IdBetStatus", "Status" },
                values: new object[,]
                {
                    { 1, "Nierozpoczęto" },
                    { 2, "W trakcie" },
                    { 3, "Wygrany" },
                    { 4, "Przegrany" }
                });

            migrationBuilder.InsertData(
                table: "Bet",
                columns: new[] { "IdBet", "Date", "IdBetEsport", "IdBetSport" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 3, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 4, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), null, 4 },
                    { 5, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 6, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 7, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 3, null }
                });

            migrationBuilder.InsertData(
                table: "BetEsportOption",
                columns: new[] { "IdBetEsportOption", "IdBetEsport", "IdBetEsportType", "IdBetStatus", "Odds" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1.5f },
                    { 2, 1, 3, 1, 5.1f },
                    { 3, 1, 2, 1, 2.9f },
                    { 4, 2, 1, 1, 1.8f },
                    { 5, 2, 3, 1, 2.5f },
                    { 6, 2, 2, 1, 6.7f },
                    { 7, 3, 1, 1, 2.5f },
                    { 8, 3, 3, 1, 6f },
                    { 9, 3, 2, 1, 1.15f }
                });

            migrationBuilder.InsertData(
                table: "BetSportOption",
                columns: new[] { "IdBetSportOption", "IdBetSport", "IdBetSportType", "IdBetStatus", "Odds" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1.3f },
                    { 2, 1, 3, 1, 1.6f },
                    { 3, 1, 2, 1, 2.5f },
                    { 4, 2, 1, 1, 1.4f },
                    { 5, 2, 3, 1, 2.4f },
                    { 6, 2, 2, 1, 2.5f },
                    { 7, 3, 1, 1, 1.9f },
                    { 8, 3, 3, 1, 4f },
                    { 9, 3, 2, 1, 1.19f },
                    { 10, 4, 1, 1, 19f },
                    { 11, 4, 3, 1, 3f },
                    { 12, 4, 2, 1, 1.7f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bet",
                keyColumn: "IdBet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bet",
                keyColumn: "IdBet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bet",
                keyColumn: "IdBet",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bet",
                keyColumn: "IdBet",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bet",
                keyColumn: "IdBet",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bet",
                keyColumn: "IdBet",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bet",
                keyColumn: "IdBet",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BetEsportOption",
                keyColumn: "IdBetEsportOption",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BetSportOption",
                keyColumn: "IdBetSportOption",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BetStatus",
                keyColumn: "IdBetStatus",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BetStatus",
                keyColumn: "IdBetStatus",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BetStatus",
                keyColumn: "IdBetStatus",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BetEsport",
                keyColumn: "IdBetEsport",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BetEsport",
                keyColumn: "IdBetEsport",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BetEsport",
                keyColumn: "IdBetEsport",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BetEsportType",
                keyColumn: "IdBetEsportType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BetEsportType",
                keyColumn: "IdBetEsportType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BetEsportType",
                keyColumn: "IdBetEsportType",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BetSport",
                keyColumn: "IdBetSport",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BetSport",
                keyColumn: "IdBetSport",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BetSport",
                keyColumn: "IdBetSport",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BetSport",
                keyColumn: "IdBetSport",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BetSportType",
                keyColumn: "IdBetSportType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BetSportType",
                keyColumn: "IdBetSportType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BetSportType",
                keyColumn: "IdBetSportType",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BetStatus",
                keyColumn: "IdBetStatus",
                keyValue: 1);
        }
    }
}
