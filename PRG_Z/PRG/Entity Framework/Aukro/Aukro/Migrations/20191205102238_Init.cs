using Microsoft.EntityFrameworkCore.Migrations;

namespace Aukro.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(unicode: false, nullable: false),
                    Password = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    AuctionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentPrice = table.Column<int>(nullable: false),
                    BuyNowPrice = table.Column<int>(nullable: true),
                    EndTime = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: false),
                    IsEnd = table.Column<bool>(nullable: false),
                    WinnerUserId = table.Column<int>(nullable: true),
                    SellerUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.AuctionId);
                    table.ForeignKey(
                        name: "FK_Auctions_Users1",
                        column: x => x.SellerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auctions_Users",
                        column: x => x.WinnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_SellerUserId",
                table: "Auctions",
                column: "SellerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_WinnerUserId",
                table: "Auctions",
                column: "WinnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
