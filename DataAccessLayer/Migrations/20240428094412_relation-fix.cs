using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class relationfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "transactionType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "roleFK",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "totqlPrice",
                table: "Transactions",
                newName: "totalPrice");

            migrationBuilder.AlterColumn<int>(
                name: "userFK",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "transactionFK",
                table: "TransactionDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AppUserId",
                table: "Transactions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_AppUserId",
                table: "Transactions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_AppUserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AppUserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Transactions",
                newName: "totqlPrice");

            migrationBuilder.AlterColumn<string>(
                name: "userFK",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "transactionType",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "transactionFK",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "roleFK",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
