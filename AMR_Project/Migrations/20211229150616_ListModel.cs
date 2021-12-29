using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class ListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListAnimesId",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListAnimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAnimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListAnimes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_ListAnimesId",
                table: "Animes",
                column: "ListAnimesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListAnimes_UserId",
                table: "ListAnimes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_ListAnimes_ListAnimesId",
                table: "Animes",
                column: "ListAnimesId",
                principalTable: "ListAnimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_ListAnimes_ListAnimesId",
                table: "Animes");

            migrationBuilder.DropTable(
                name: "ListAnimes");

            migrationBuilder.DropIndex(
                name: "IX_Animes_ListAnimesId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "ListAnimesId",
                table: "Animes");
        }
    }
}
