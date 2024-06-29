using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class drug_supplier_relation_fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Suppliers_supplierid",
                table: "Drugs");

            migrationBuilder.RenameColumn(
                name: "supplierid",
                table: "Drugs",
                newName: "supplierFK");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_supplierid",
                table: "Drugs",
                newName: "IX_Drugs_supplierFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Suppliers_supplierFK",
                table: "Drugs",
                column: "supplierFK",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Suppliers_supplierFK",
                table: "Drugs");

            migrationBuilder.RenameColumn(
                name: "supplierFK",
                table: "Drugs",
                newName: "supplierid");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_supplierFK",
                table: "Drugs",
                newName: "IX_Drugs_supplierid");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Suppliers_supplierid",
                table: "Drugs",
                column: "supplierid",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
