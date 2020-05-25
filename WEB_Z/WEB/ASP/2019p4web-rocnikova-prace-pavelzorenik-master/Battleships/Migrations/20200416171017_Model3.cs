using Microsoft.EntityFrameworkCore.Migrations;

namespace Battleships.Migrations
{
    public partial class Model3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPlaced",
                table: "Ships",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlaced",
                table: "Ships");
        }
    }
}
