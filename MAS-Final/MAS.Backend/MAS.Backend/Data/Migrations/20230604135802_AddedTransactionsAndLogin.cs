using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAS.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTransactionsAndLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "User",
                type: "varchar(64)",
                unicode: false,
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "BankAccount",
                table: "Account",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    IdTransactionType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TransactionType_pk", x => x.IdTransactionType);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    IdTransaction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    IdTransactionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Transaction_pk", x => x.IdTransaction);
                    table.ForeignKey(
                        name: "Transaction_Account",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "IdAccount");
                    table.ForeignKey(
                        name: "Transaction_TransactionType",
                        column: x => x.IdTransactionType,
                        principalTable: "TransactionType",
                        principalColumn: "IdTransactionType");
                });

            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "IdTransactionType", "Type" },
                values: new object[,]
                {
                    { 1, "Wypłata" },
                    { 2, "Wpłata" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdAccount",
                table: "Transaction",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdTransactionType",
                table: "Transaction",
                column: "IdTransactionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "BankAccount",
                table: "Account",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
