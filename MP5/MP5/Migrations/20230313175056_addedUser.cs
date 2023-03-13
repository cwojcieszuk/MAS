using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP5.Migrations
{
    public partial class addedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "IdPlayer", "BirthDate", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, new DateTime(1984, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan@gmail.com", "Jan", "Kowalski", 123456789 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "IdPlayer",
                keyValue: 1);
        }
    }
}
