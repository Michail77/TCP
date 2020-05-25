using Microsoft.EntityFrameworkCore.Migrations;

namespace CSFD.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MovieActors_ActorId_MovieId",
                table: "MovieActors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_MovieId",
                table: "Actors");

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 1m, 1m });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Actors");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MovieActors",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieActors",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Actors",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Samuel L.", "Jackson" },
                    { 2, "Samuel A.", "Jackson" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pulp Fiction" },
                    { 2, "Pulp Fiction 2" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "ActorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "ActorId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors");

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                table: "Movies",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ActorId",
                table: "MovieActors",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "MovieId",
                table: "MovieActors",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                table: "Actors",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "MovieId",
                table: "Actors",
                type: "decimal(20,0)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MovieActors_ActorId_MovieId",
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName", "MovieId" },
                values: new object[] { 1m, "Samuel L.", "Jackson", null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1m, "Pulp Fiction" });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "ActorId" },
                values: new object[] { 1m, 1m });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                table: "Actors",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
