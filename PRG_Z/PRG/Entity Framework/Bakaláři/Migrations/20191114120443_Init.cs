using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Nazev = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Jmeno = table.Column<string>(maxLength: 10, nullable: false),
                    Prijmeni = table.Column<string>(nullable: false),
                    ClassroomId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Nazev" },
                values: new object[,]
                {
                    { 1L, "P1" },
                    { 2L, "P2" },
                    { 3L, "P3" },
                    { 4L, "P4" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassroomId", "Jmeno", "Prijmeni" },
                values: new object[,]
                {
                    { 1L, 1L, "A", "B" },
                    { 2L, 1L, "C", "D" },
                    { 3L, 2L, "E", "F" },
                    { 4L, 3L, "G", "H" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
