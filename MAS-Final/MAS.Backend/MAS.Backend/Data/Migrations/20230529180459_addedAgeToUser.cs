using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedAgeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BetSportType",
                keyColumn: "IdBetSportType",
                keyValue: 2,
                column: "Name",
                value: "Wygra 2 drużyna");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.UpdateData(
                table: "BetSportType",
                keyColumn: "IdBetSportType",
                keyValue: 2,
                column: "Name",
                value: "Wygra 1 drużyna");
        }
    }
}
