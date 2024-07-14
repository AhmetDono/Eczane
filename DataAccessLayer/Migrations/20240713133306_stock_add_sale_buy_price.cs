using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class stock_add_sale_buy_price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Stocks",
                newName: "salePrice");

            migrationBuilder.AddColumn<double>(
                name: "buyPrice",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "buyPrice",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "salePrice",
                table: "Stocks",
                newName: "price");
        }
    }
}
