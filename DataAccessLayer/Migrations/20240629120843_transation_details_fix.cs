using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class transation_details_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_Drugs_DrugNDC",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_DrugNDC",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "DrugNDC",
                table: "TransactionDetails");

            migrationBuilder.AlterColumn<int>(
                name: "drugFK",
                table: "TransactionDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_drugFK",
                table: "TransactionDetails",
                column: "drugFK");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_Drugs_drugFK",
                table: "TransactionDetails",
                column: "drugFK",
                principalTable: "Drugs",
                principalColumn: "NDC",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_Drugs_drugFK",
                table: "TransactionDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_drugFK",
                table: "TransactionDetails");

            migrationBuilder.AlterColumn<string>(
                name: "drugFK",
                table: "TransactionDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DrugNDC",
                table: "TransactionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_DrugNDC",
                table: "TransactionDetails",
                column: "DrugNDC");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_Drugs_DrugNDC",
                table: "TransactionDetails",
                column: "DrugNDC",
                principalTable: "Drugs",
                principalColumn: "NDC",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
