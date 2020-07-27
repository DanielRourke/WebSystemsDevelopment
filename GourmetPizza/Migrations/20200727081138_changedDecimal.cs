using Microsoft.EntityFrameworkCore.Migrations;

namespace GourmetPizza.Migrations
{
    public partial class changedDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Pizza",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Pizza",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
