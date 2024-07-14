using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class fix_stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Drugs_DrugNDC",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_DrugNDC",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "DrugNDC",
                table: "Stocks");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_DrugFK",
                table: "Stocks",
                column: "DrugFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Drugs_DrugFK",
                table: "Stocks",
                column: "DrugFK",
                principalTable: "Drugs",
                principalColumn: "NDC",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Drugs_DrugFK",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_DrugFK",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "DrugNDC",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_DrugNDC",
                table: "Stocks",
                column: "DrugNDC");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Drugs_DrugNDC",
                table: "Stocks",
                column: "DrugNDC",
                principalTable: "Drugs",
                principalColumn: "NDC",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
