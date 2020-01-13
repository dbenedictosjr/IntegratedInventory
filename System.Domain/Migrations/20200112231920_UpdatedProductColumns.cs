using Microsoft.EntityFrameworkCore.Migrations;

namespace System.Domain.Migrations
{
    public partial class UpdatedProductColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mintock",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "MinStock",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinStock",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "Mintock",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
