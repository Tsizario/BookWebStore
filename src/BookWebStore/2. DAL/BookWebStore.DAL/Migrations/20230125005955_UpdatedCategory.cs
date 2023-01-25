using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWebStore.DAL.Migrations
{
    public partial class UpdatedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ListPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
