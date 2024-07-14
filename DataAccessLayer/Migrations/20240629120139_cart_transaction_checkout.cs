using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class cart_transaction_checkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_AppUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_Transactions_Transactionid",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_Transactionid",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AppUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Transactionid",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "posta",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "userFK",
                table: "Addresses",
                newName: "UserFK");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Addresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Addresses",
                newName: "Country");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AddressId",
                table: "Transactions",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_transactionFK",
                table: "TransactionDetails",
                column: "transactionFK");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserFK",
                table: "Addresses",
                column: "UserFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserFK",
                table: "Addresses",
                column: "UserFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_Transactions_transactionFK",
                table: "TransactionDetails",
                column: "transactionFK",
                principalTable: "Transactions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Addresses_AddressId",
                table: "Transactions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserFK",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_Transactions_transactionFK",
                table: "TransactionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Addresses_AddressId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AddressId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_transactionFK",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserFK",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "UserFK",
                table: "Addresses",
                newName: "userFK");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Addresses",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Addresses",
                newName: "country");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Transactionid",
                table: "TransactionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "posta",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_Transactionid",
                table: "TransactionDetails",
                column: "Transactionid");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AppUserId",
                table: "Addresses",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_AppUserId",
                table: "Addresses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_Transactions_Transactionid",
                table: "TransactionDetails",
                column: "Transactionid",
                principalTable: "Transactions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
