using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedAccountRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
