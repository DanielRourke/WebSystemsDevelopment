using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GourmetPizza.Migrations
{
    public partial class customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyName = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
